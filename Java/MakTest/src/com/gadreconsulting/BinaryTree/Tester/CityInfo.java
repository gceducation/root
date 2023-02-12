package com.gadreconsulting.BinaryTree.Tester;

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

	public double getDistance(CityInfo cityInfoOther) {
		// User simple cartesian formula for now.
		double q = getDistanceHaversine(this._qLat , this._qLon, cityInfoOther._qLat,cityInfoOther._qLon);
		return q;
	}

	private static double getDistanceHaversine(double qLat1, double qLon1, double qLat2, double qLon2) {
// distance between latitudes and longitudes using Haversine distance
		double qLat = Math.toRadians(qLat2 - qLat1);
		double qLon = Math.toRadians(qLon2 - qLon1);
		qLat1 = Math.toRadians(qLat1);
		qLat2 = Math.toRadians(qLat2);
		double qTemp = Math.pow(Math.sin(qLat / 2), 2)
				+ Math.pow(Math.sin(qLon / 2), 2) * Math.cos(qLat1) * Math.cos(qLat2);
		double qRad = 6371;
		qTemp = 2 * Math.asin(Math.sqrt(qTemp));
		return qRad * qTemp;
	}

	public String toString() {
		if (_sForToString == null) {
			_sForToString = _sName + "(" + _sCountry + ")";
		}
		return _sForToString;
	}
}