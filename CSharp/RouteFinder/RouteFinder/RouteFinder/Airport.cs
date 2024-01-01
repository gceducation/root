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
        private static Random rng = new Random(12);
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

        int IComparable<Airport>.CompareTo(Airport other)
        {
            return (this._sIATACode.CompareTo(other._sIATACode));
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

        public static AirRoute FindRoutes(Dictionary<String, Airport> dctAirportAll, String sIATACodeFm, String sIATACodeTo, int jOptions)
        {
            AirRoute airRoute = new AirRoute(dctAirportAll, sIATACodeFm, sIATACodeTo, jOptions);
            airRoute.FindRoutes();
            return airRoute;
        }


        public class AirRoute
        {
            public String _sIATACodeFm;
            public String _sIATACodeTo;
            public int _jOptions;
            public Dictionary<String, Airport> _dctAirportAll;
            public AirRoute(Dictionary<String, Airport> dctAirportAll, String sIATACodeFm, String sIATACodeTo, int jOptions)
            {
                _sIATACodeFm = sIATACodeFm;
                _sIATACodeTo = sIATACodeTo;
                _jOptions = jOptions;
                _dctAirportAll = dctAirportAll;
            }
            public List<List<Airport>> _lstlstAirport;
            public List<List<Airport>> _lstlstRoutes;

            internal void FindRoutes()
            {
                Airport aptFm = this._dctAirportAll[_sIATACodeFm];
                Airport aptCur = aptFm;
                Airport aptTo = this._dctAirportAll[_sIATACodeTo];
                int jListId = 0;
                int jPos = 0;
                this._lstlstAirport = new List<List<Airport>>();
                this._lstlstAirport.Add(new List<Airport>());
                this._lstlstRoutes = new List<List<Airport>>();
                List<Airport> lstAptCur = new List<Airport>();
                FindRoutesRecursive(aptFm, aptTo, aptCur, jListId, jPos, lstAptCur);
            }

            private void FindRoutesRecursive(Airport aptFm, Airport aptTo, Airport aptCur, int jListId, int jPos, List<Airport> lstAptCur)
            {
                lstAptCur.Add(aptCur);
                int jCountStart = lstAptCur.Count;
                if (String.Compare(aptCur._sIATACode, aptTo._sIATACode) == 0)
                {
                    List<Airport> lstRepl = ReplicateList(this._lstlstAirport[jListId]);
                    this._lstlstRoutes.Add(lstRepl);

                }
                else
                {
                    int j;
                    for (j = 0; j < aptCur._dctAirportDep.Count; j++)
                    {
                        KeyValuePair<String, Airport> kvp = aptCur._dctAirportDep.ElementAt(j);
                        Airport aptAlready = this._lstlstAirport[jListId].FirstOrDefault(o => String.Compare(o._sIATACode, kvp.Key) == 0);
                        if (aptAlready != null)
                        {
                            continue;
                        }

                        this._lstlstAirport[jListId].Add(aptCur);
                        jPos++;
                        Airport aptNext = kvp.Value;
                        FindRoutesRecursive(aptFm, aptTo, aptNext, jListId, jPos, lstAptCur);
                    }
                }
                int jCountEnd = lstAptCur.Count;
                lstAptCur.RemoveAt(jCountStart - 1);
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
}
