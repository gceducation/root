package com.gadreconsulting.graph;

import com.gadreconsulting.BinaryTree.Tester.CityInfo;
import com.gadreconsulting.DynamicArray.DynamicArray;

public class TravelPath {
	DynamicArray<DataNode<CityInfo>> _dynaCityInfo;
	Double _qDist;

	public TravelPath(DynamicArray<DataNode<CityInfo>> dynaCityInfo) {
		_dynaCityInfo = dynaCityInfo;
		_qDist = 0.0;

		int j;
		CityInfo ciOrigin = dynaCityInfo.get(0)._objData;
		for (j = 1; j < dynaCityInfo.size(); j++) {
			CityInfo ciDestination = dynaCityInfo.get(j)._objData;
			_qDist += ciDestination.getDistance(ciOrigin);
			ciOrigin = ciDestination;
		}

	}
}