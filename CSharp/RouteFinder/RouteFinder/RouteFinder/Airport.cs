using System;
using System.Collections.Generic;
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
        public String ToString()
        {
            return _sIATACode + " - " + _sName;
        }
        public static Dictionary<String, Airport> InitializeFromTSV(String sFQN, bool fTwoWayLink = true)
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
    }
}
