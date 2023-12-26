using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder
{
    public class Airport
    {
        public String _sName;
        public String _sIATACode;
        public float _rLat;
        public float _rLon;
        public float _rAltitude;
        public List<Airport> _lstAirportDep;
        public List<Airport> _lstAirportArr;

        public Airport(string sName, string sIATACode, float rLat, float rLon, float rAltitude, List<Airport> lstAirportDep, List<Airport> lstAirportArr)
        {
            _sName = sName;
            _sIATACode = sIATACode;
            _rLat = rLat;
            _rLon = rLon;
            _rAltitude = rAltitude;
            _lstAirportDep = lstAirportDep;
            _lstAirportArr = lstAirportArr;
        }
    }
}
