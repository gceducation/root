package com.gadreconsulting.graph;

public class CityInfo implements Comparable<CityInfo> {
	public String _sName;
	public double _qLat;
	public double _qLon;
	public String _sCountry;
	public long _nPopulation;
	private String _sForToString;

	public CityInfo(String sName, double qLat, double qLon, String sCountry, long nPopulation) {
		_sName = sName;
		_qLat = qLat;
		_qLon = qLon;
		_sCountry = sCountry;
		_nPopulation = nPopulation;
		_sForToString = null;
	}
	public CityInfo(String sName, String sCountry) {
			this(sName, Double.NaN, Double.NaN, sCountry, Long.MIN_VALUE);
	}
	@Override
	public int compareTo(CityInfo cityInfoOther) {
		return this.toString().compareTo(cityInfoOther.toString());

	}

	public String toString() {
		if (_sForToString == null) {
			_sForToString = _sName + "(" + _sCountry + ")";
			
		}
		return _sForToString; 			
	}
}