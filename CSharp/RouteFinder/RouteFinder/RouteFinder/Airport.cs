using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder
{
    public class Airport : IComparable<Airport>
    {
        public String _sName;
        public String _sIATACode;
        public float _rLat;
        public float _rLon;
        public float _rAltitude;
        public Dictionary<String, Airport> _dctAirportDep;
        public Dictionary<String, Airport> _dctAirportArr;
        private static Random rng = new Random(120);
        public static Dictionary<String, Airport> __dctAirportAll = null;
        public override String ToString()
        {
            return _sIATACode + " - " + _sName;
        }
        public static Dictionary<String, Airport> InitializeFmTSV(String sFQN, bool fTwoWayLink = true)
        {
            Dictionary<String, Airport> dctAirport = new Dictionary<string, Airport>();
            string[] arrLines = File.ReadAllLines(sFQN);
            int i;
            for (i = 1; i < arrLines.Length; i++)
            {
                String sTemp = arrLines[i].Trim();
                if (sTemp.Length == 0)
                {
                    continue;
                }
                String[] arrsParts = arrLines[i].Split('\t');
                string sName = arrsParts[2] + " - " + arrsParts[7];
                string sIATACode = arrsParts[9];
                float rAltitude = float.Parse(arrsParts[3]);
                String[] arrsLatLon = arrsParts[11].Split(',');
                float rLat = float.Parse(arrsLatLon[1]);
                float rLon = float.Parse(arrsLatLon[0]);
                Dictionary<String, Airport> lstAirportDep = new Dictionary<string, Airport>();
                Dictionary<String, Airport> lstAirportArr = new Dictionary<string, Airport>();
                Airport airport = new Airport(sName, sIATACode, rLat, rLon, rAltitude, lstAirportDep, lstAirportArr);
                dctAirport.Add(sIATACode, airport);
            }
            for (i = 0; i < dctAirport.Count; i++)
            {
                Airport apCur = dctAirport.ElementAt(i).Value;
                for (int iTo = 0; iTo < dctAirport.Count; iTo++)
                {
                    if (iTo != i)
                    {
                        if (rng.Next(100) < 30)
                        {
                            Airport apTo = dctAirport.ElementAt(iTo).Value;
                            if (!apCur._dctAirportDep.ContainsKey(apTo._sIATACode))
                            {
                                apCur._dctAirportDep.Add(apTo._sIATACode, apTo);
                                apTo._dctAirportArr.Add(apCur._sIATACode, apCur);
                                if (fTwoWayLink)
                                {
                                    apCur._dctAirportArr.Add(apTo._sIATACode, apTo);
                                    apTo._dctAirportDep.Add(apCur._sIATACode, apCur);
                                }

                            }
                        }
                    }
                }
            }
            __dctAirportAll = dctAirport;
            return dctAirport;

        }

        int IComparable<Airport>.CompareTo(Airport apOther)
        {
            return (this._sIATACode.CompareTo(apOther._sIATACode));
        }

        public Airport(string sName, string sIATACode, float rLat, float rLon, float rAltitude, Dictionary<String, Airport> lstAirportDep, Dictionary<String, Airport> lstAirportArr)
        {
            _sName = sName;
            _sIATACode = sIATACode;
            _rLat = rLat;
            _rLon = rLon;
            _rAltitude = rAltitude;
            _dctAirportDep = lstAirportDep;
            _dctAirportArr = lstAirportArr;
        }

        public static AirRoutes FindRoutes(Dictionary<String, Airport> dctAirportAll, String sIATACodeFm, String sIATACodeTo, int jHopsCountMax)
        {
            AirRoutes airRoute = new AirRoutes(dctAirportAll, sIATACodeFm, sIATACodeTo, jHopsCountMax);
            airRoute.FindRoutes();
            return airRoute;
        }

        public class AirportDist : IComparable<AirportDist>
        {
            public Airport _apStart;
            public Airport _apEnd;
            public double _qDist;
            public AirportDist(Airport apStart, Airport apEnd)
            {
                this._apStart = apStart;
                this._apEnd = apEnd;
                _qDist = Util.GetDistance(apStart._rLat, apStart._rLon, apEnd._rLat, apEnd._rLon);
            }
  
            int IComparable<AirportDist>.CompareTo(AirportDist apdOther)
            {
                return Math.Sign(this._qDist - apdOther._qDist);
            }
        }
        public class AirRoutes
        {
            private static Random rng = new Random();
            public class AirSegment : IComparable<AirSegment>
            {
                public AirSegment(List<AirportDist> lstApDist)
                {
                    this._lstApDist = lstApDist;
                    _qDist = lstApDist.Sum(o => o._qDist);
                    _qPrice = _qDist * rng.Next(30, 90);
                    _qTime = _qDist / rng.Next(600, 1200);
                }
                public List<AirportDist> _lstApDist;
                public double _qDist;
                public double _qPrice;
                public double _qTime;

                int IComparable<AirSegment>.CompareTo(AirSegment airSegOther)
                {
                    return Math.Sign(this._qDist - airSegOther._qDist);
                }
            }
            public String _sIATACodeFm;
            public String _sIATACodeTo;
            public int _jHopsCountMax;
            public Dictionary<String, Airport> _dctAirportAll;
            public AirRoutes(Dictionary<String, Airport> dctAirportAll, String sIATACodeFm, String sIATACodeTo, int jHopsCountMax)
            {
                _sIATACodeFm = sIATACodeFm;
                _sIATACodeTo = sIATACodeTo;
                _jHopsCountMax = jHopsCountMax;
                _dctAirportAll = dctAirportAll;
            }
            public List<List<Airport>> _lstlstRoutes = new List<List<Airport>>();
            public List<List<AirportDist>> _lstHops = new List<List<AirportDist>>();
            public List<AirSegment> _lstAirSegments = new List<AirSegment>();

            internal void FindRoutes()
            {
                Airport aptFm = this._dctAirportAll[_sIATACodeFm];
                Airport aptCur = aptFm;
                Airport aptTo = this._dctAirportAll[_sIATACodeTo];

                List<Airport> lstAptCur = new List<Airport>();
                
                FindRoutesRecursive(0, 0, aptFm, aptTo, aptCur, lstAptCur);
                foreach (List<Airport> lstApt in this._lstlstRoutes)
                {
                    List<AirportDist> lstApDist = new List<AirportDist>();
                    for (int i = 0; i < lstApt.Count - 1; i++)
                    {
                        AirportDist apd = new AirportDist(lstApt[i], lstApt[i + 1]);
                        lstApDist.Add(apd);
                    }
                  
                    AirSegment airSeg = new AirSegment(lstApDist);
                    _lstAirSegments.Add(airSeg);

                }
                _lstAirSegments.Sort();
            }

            private void FindRoutesRecursive(int jCurHop, int jFound, Airport aptFm, Airport aptTo, Airport aptCur, List<Airport> lstAptCur)
            {
                jCurHop++;
                if (jCurHop < this._jHopsCountMax)
                {
                    lstAptCur.Add(aptCur);
                    int jCountStart = lstAptCur.Count;
                    if (String.Compare(aptCur._sIATACode, aptTo._sIATACode) == 0)
                    {
                        Airport aptLast = lstAptCur[lstAptCur.Count - 2];
                        List<Airport> lstRepl = ReplicateList(lstAptCur);
                        this._lstlstRoutes.Add(lstRepl);
                       
                        Console.WriteLine("Found via " + aptLast);
                        if (_lstlstRoutes.Count > 10)
                        {

                        }

                    }
                    else
                    {
                        int j;
                        for (j = 0; j < aptCur._dctAirportDep.Count; j++)
                        {
                            KeyValuePair<String, Airport> kvp = aptCur._dctAirportDep.ElementAt(j);
                            Airport aptAlready = lstAptCur.FirstOrDefault(o => String.Compare(o._sIATACode, kvp.Key) == 0);
                            if (aptAlready != null)
                            {
                                continue;
                            }

                            //this._lstlstAirport[jListId].Add(aptCur);
                            Airport aptNext = kvp.Value;
                            FindRoutesRecursive(jCurHop, jFound, aptFm, aptTo, aptNext, lstAptCur);
                        }
                    }
                    int jCountEnd = lstAptCur.Count;
                    lstAptCur.RemoveAt(jCountStart - 1);
                }

            }

            private List<Airport> ReplicateList(List<Airport> lstAirport)
            {
                List<Airport> lstRet = new List<Airport>();
                foreach (Airport apt in lstAirport)
                {
                    lstRet.Add(apt);
                }
                return lstRet;
            }
        }
    }
    public class Util
    {
        public static double GetDistance(double rLat1, double rLon1, double rLat2, double rLon2)
        {
            double rLat1Rad = rLat1 * (Math.PI / 180.0);
            double rLon1Rad = rLon1 * (Math.PI / 180.0);
            double rLat2Rad = rLat2 * (Math.PI / 180.0);
            double rLon2Rad = rLon2 * (Math.PI / 180.0) - rLon1Rad;
            double q = Math.Pow(Math.Sin((rLat2Rad - rLat1Rad) / 2.0), 2.0) + Math.Cos(rLat1Rad) * Math.Cos(rLat2Rad) * Math.Pow(Math.Sin(rLon2Rad / 2.0), 2.0);
            q = 6371.0 * (2.0 * Math.Atan2(Math.Sqrt(q), Math.Sqrt(1.0 - q)));
            return q;
        }

    }
}
