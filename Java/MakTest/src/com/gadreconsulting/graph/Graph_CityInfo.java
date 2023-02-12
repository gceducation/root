package com.gadreconsulting.graph;

import java.util.HashMap;

import com.gadreconsulting.BinaryTree.Tester.CityInfo;
import com.gadreconsulting.DynamicArray.DynamicArray;

public class Graph_CityInfo {

	HashMap<String, DataNode<CityInfo>> _hmDataNodeByUniqId = new HashMap<>();
	DynamicArray<DataNode<CityInfo>> _dynArrCityInfoObj;

	public Graph_CityInfo(DynamicArray<DataNode<CityInfo>> dynArrCityInfoObj) {
		_dynArrCityInfoObj = dynArrCityInfoObj;
		for (int j = 0; j < dynArrCityInfoObj.size(); j++) {
			DataNode<CityInfo> dn = dynArrCityInfoObj.get(j);
			_hmDataNodeByUniqId.put(dn._sUniqId, dn);
		}
	}

	public int _jPathsFound = 0;

	public DynamicArray<DynamicArray<DataNode<CityInfo>>> computePaths(String sUniqIdOrig, String sUniqIdDest, int nStageMax) {
		DynamicArray<DynamicArray<DataNode<CityInfo>>> dynadynaPaths = null;
		DataNode<CityInfo> dnOrig = _hmDataNodeByUniqId.get(sUniqIdOrig);
		DataNode<CityInfo> dnDest = _hmDataNodeByUniqId.get(sUniqIdDest);
		dynadynaPaths = new DynamicArray<DynamicArray<DataNode<CityInfo>>>();
		DynamicArray<DataNode<CityInfo>> dynArrayWorking = new DynamicArray<>();
		dynArrayWorking.add(dnOrig);
		_jPathsFound = 0;
		boolean f = computePathsRecursive(dnOrig, dnOrig, dnDest, dynArrayWorking, dynadynaPaths, nStageMax, 0);
		System.out.println("paths count =" + _jPathsFound);
		return dynadynaPaths;

	}

	private boolean computePathsRecursive(DataNode<CityInfo> dnOrig, DataNode<CityInfo> dnCurrent,
			DataNode<CityInfo> dnDest, DynamicArray<DataNode<CityInfo>> dynArrayWorking,
			DynamicArray<DynamicArray<DataNode<CityInfo>>> dynadynaPaths, int nStageMax, int nStageCur) {
		boolean fRet = false;
		if (dnCurrent== dnDest) {
			_jPathsFound++;
			DynamicArray<DataNode<CityInfo>> dynaci = new DynamicArray<DataNode<CityInfo>>();
			for (int j = 0; j < dynArrayWorking.size(); j++) {
				DataNode<CityInfo> dnT = dynArrayWorking.get(j);
				dynaci.add(dnT);			
			}			
			dynadynaPaths.add(dynaci);
			System.out.println();
			fRet = true;
		} else {
			if (nStageCur < nStageMax) {
				nStageCur++;
			for (int j = 0; j < dnCurrent._dynArrLinkedNode.size(); j++) {
				DataNode<CityInfo> dnNext = dnCurrent._dynArrLinkedNode.get(j);
				if (!dynArrayWorking.fContains(dnNext)) {
					dynArrayWorking.add(dnNext);
					int jDynArrayPos = dynArrayWorking.size();
					computePathsRecursive(dnOrig, dnNext, dnDest, dynArrayWorking, dynadynaPaths,nStageMax, nStageCur);
					dynArrayWorking.removeAt(jDynArrayPos - 1);

				}
			}
		}
		}
		return fRet;

	}
}
