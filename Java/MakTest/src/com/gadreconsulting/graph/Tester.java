package com.gadreconsulting.graph;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import com.gadreconsulting.BinaryTree.Tester.CityInfo;
import com.gadreconsulting.DynamicArray.DynamicArray;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author gadre
 */
public class Tester {

	/**
	 * @param args the command line arguments
	 */
	public static void main(String[] args) {
		DynamicArray<DataNode<CityInfo>> dynArrCityInfoObj = new DynamicArray<DataNode<CityInfo>>();
		int j = 0;
		CityInfo ciTokyo = new CityInfo("Tokyo", 35.6897, 139.6922, "Japan", 37977000);
		DataNode<CityInfo> dnciTokyo = new DataNode<CityInfo>(ciTokyo);
		dynArrCityInfoObj.add(dnciTokyo);
		CityInfo ciDelhi = new CityInfo("Delhi", 28.66, 77.23, "India", 29617000);
		DataNode<CityInfo> dnciDelhi = new DataNode<CityInfo>(ciDelhi);
		dynArrCityInfoObj.add(dnciDelhi);
		CityInfo ciMumbai = new CityInfo("Mumbai", 18.9667, 72.8333, "India", 23355000);
		DataNode<CityInfo> dnciMumbai = new DataNode<CityInfo>(ciMumbai);
		dynArrCityInfoObj.add(dnciMumbai);
		CityInfo ciSaoPaulo = new CityInfo("Sao Paulo", -23.5504, -46.6339, "Brazil", 22046000);
		DataNode<CityInfo> dnciSaoPaulo = new DataNode<CityInfo>(ciSaoPaulo);
		dynArrCityInfoObj.add(dnciSaoPaulo);
		CityInfo ciSeoul = new CityInfo("Seoul", 37.5833, 127, "Korea, South", 21794000);
		DataNode<CityInfo> dnciSeoul = new DataNode<CityInfo>(ciSeoul);
		dynArrCityInfoObj.add(dnciSeoul);
		CityInfo ciNewYork = new CityInfo("New York", 40.6943, -73.9249, "United States", 18713220);
		DataNode<CityInfo> dnciNewYork = new DataNode<CityInfo>(ciNewYork);
		dynArrCityInfoObj.add(dnciNewYork);
		CityInfo ciMoscow = new CityInfo("Moscow", 55.7558, 37.6178, "Russia", 17125000);
		DataNode<CityInfo> dnciMoscow = new DataNode<CityInfo>(ciMoscow);
		dynArrCityInfoObj.add(dnciMoscow);
		CityInfo ciBuenosAires = new CityInfo("Buenos Aires", -34.5997, -58.3819, "Argentina", 16157000);
		DataNode<CityInfo> dnciBuenosAires = new DataNode<CityInfo>(ciBuenosAires);
		dynArrCityInfoObj.add(dnciBuenosAires);
		CityInfo ciBangalore = new CityInfo("Bangalore", 12.9699, 77.598, "India", 13707000);
		DataNode<CityInfo> dnciBangalore = new DataNode<CityInfo>(ciBangalore);
		dynArrCityInfoObj.add(dnciBangalore);
		CityInfo ciLosAngeles = new CityInfo("Los Angeles", 34.1139, -118.4068, "United States", 12750807);
		DataNode<CityInfo> dnciLosAngeles = new DataNode<CityInfo>(ciLosAngeles);
		dynArrCityInfoObj.add(dnciLosAngeles);
		CityInfo ciChennai = new CityInfo("Chennai", 13.0825, 80.275, "India", 11324000);
		DataNode<CityInfo> dnciChennai = new DataNode<CityInfo>(ciChennai);
		dynArrCityInfoObj.add(dnciChennai);
		CityInfo ciParis = new CityInfo("Paris", 48.8566, 2.3522, "France", 11020000);
		DataNode<CityInfo> dnciParis = new DataNode<CityInfo>(ciParis);
		dynArrCityInfoObj.add(dnciParis);
		CityInfo ciLondon = new CityInfo("London", 51.5072, -0.1275, "United Kingdom", 10979000);
		DataNode<CityInfo> dnciLondon = new DataNode<CityInfo>(ciLondon);
		dynArrCityInfoObj.add(dnciLondon);
		CityInfo ciChicago = new CityInfo("Chicago", 41.8373, -87.6862, "United States", 8604203);
		DataNode<CityInfo> dnciChicago = new DataNode<CityInfo>(ciChicago);
		dynArrCityInfoObj.add(dnciChicago);
		CityInfo ciPune = new CityInfo("Pune", 18.5196, 73.8553, "India", 7764000);
		DataNode<CityInfo> dnciPune = new DataNode<CityInfo>(ciPune);
		dynArrCityInfoObj.add(dnciPune);
		CityInfo ciSeattle = new CityInfo("Seattle", 47.6211, -122.3244, "United States", 3789215);
		DataNode<CityInfo> dnciSeattle = new DataNode<CityInfo>(ciSeattle);
		dynArrCityInfoObj.add(dnciSeattle);
		dnciBangalore.establishTwoWayLink(dnciChennai);
		dnciBangalore.establishTwoWayLink(dnciDelhi);
		dnciBangalore.establishTwoWayLink(dnciLondon);
		dnciBangalore.establishTwoWayLink(dnciMumbai);
		dnciBangalore.establishTwoWayLink(dnciNewYork);
		dnciBangalore.establishTwoWayLink(dnciParis);
		dnciBangalore.establishTwoWayLink(dnciPune);
		dnciBuenosAires.establishTwoWayLink(dnciChicago);
		dnciBuenosAires.establishTwoWayLink(dnciLondon);
		dnciBuenosAires.establishTwoWayLink(dnciLosAngeles);
		dnciBuenosAires.establishTwoWayLink(dnciNewYork);
		dnciBuenosAires.establishTwoWayLink(dnciParis);
		dnciBuenosAires.establishTwoWayLink(dnciSaoPaulo);
		dnciBuenosAires.establishTwoWayLink(dnciSeoul);
		dnciBuenosAires.establishTwoWayLink(dnciTokyo);
		dnciChennai.establishTwoWayLink(dnciDelhi);
		dnciChennai.establishTwoWayLink(dnciLondon);
		dnciChennai.establishTwoWayLink(dnciMumbai);
		dnciChennai.establishTwoWayLink(dnciNewYork);
		dnciChennai.establishTwoWayLink(dnciParis);
		dnciChennai.establishTwoWayLink(dnciPune);
		dnciChennai.establishTwoWayLink(dnciSeoul);
		dnciChennai.establishTwoWayLink(dnciTokyo);
		dnciChicago.establishTwoWayLink(dnciLondon);
		dnciChicago.establishTwoWayLink(dnciLosAngeles);
		dnciChicago.establishTwoWayLink(dnciMoscow);
		dnciChicago.establishTwoWayLink(dnciMumbai);
		dnciChicago.establishTwoWayLink(dnciNewYork);
		dnciChicago.establishTwoWayLink(dnciParis);
		dnciChicago.establishTwoWayLink(dnciSeattle);
		dnciChicago.establishTwoWayLink(dnciTokyo);
		dnciDelhi.establishTwoWayLink(dnciLondon);
		dnciDelhi.establishTwoWayLink(dnciLosAngeles);
		dnciDelhi.establishTwoWayLink(dnciMoscow);
		dnciDelhi.establishTwoWayLink(dnciMumbai);
		dnciDelhi.establishTwoWayLink(dnciNewYork);
		dnciDelhi.establishTwoWayLink(dnciParis);
		dnciDelhi.establishTwoWayLink(dnciPune);
		dnciDelhi.establishTwoWayLink(dnciSeoul);
		dnciDelhi.establishTwoWayLink(dnciTokyo);
		dnciLondon.establishTwoWayLink(dnciLosAngeles);
		dnciLondon.establishTwoWayLink(dnciMoscow);
		dnciLondon.establishTwoWayLink(dnciMumbai);
		dnciLondon.establishTwoWayLink(dnciNewYork);
		dnciLondon.establishTwoWayLink(dnciParis);
		dnciLondon.establishTwoWayLink(dnciSaoPaulo);
		dnciLondon.establishTwoWayLink(dnciSeattle);
		dnciLondon.establishTwoWayLink(dnciSeoul);
		dnciLondon.establishTwoWayLink(dnciTokyo);
		dnciLosAngeles.establishTwoWayLink(dnciMoscow);
		dnciLosAngeles.establishTwoWayLink(dnciMumbai);
		dnciLosAngeles.establishTwoWayLink(dnciNewYork);
		dnciLosAngeles.establishTwoWayLink(dnciParis);
		dnciLosAngeles.establishTwoWayLink(dnciSaoPaulo);
		dnciLosAngeles.establishTwoWayLink(dnciSeattle);
		dnciLosAngeles.establishTwoWayLink(dnciSeoul);
		dnciLosAngeles.establishTwoWayLink(dnciTokyo);
		dnciMoscow.establishTwoWayLink(dnciMumbai);
		dnciMoscow.establishTwoWayLink(dnciNewYork);
		dnciMoscow.establishTwoWayLink(dnciParis);
		dnciMoscow.establishTwoWayLink(dnciSeattle);
		dnciMoscow.establishTwoWayLink(dnciSeoul);
		dnciMoscow.establishTwoWayLink(dnciTokyo);
		dnciMumbai.establishTwoWayLink(dnciNewYork);
		dnciMumbai.establishTwoWayLink(dnciParis);
		dnciMumbai.establishTwoWayLink(dnciPune);
		dnciMumbai.establishTwoWayLink(dnciSeoul);
		dnciMumbai.establishTwoWayLink(dnciTokyo);
		dnciNewYork.establishTwoWayLink(dnciParis);
		dnciNewYork.establishTwoWayLink(dnciSaoPaulo);
		dnciNewYork.establishTwoWayLink(dnciSeattle);
		dnciNewYork.establishTwoWayLink(dnciSeoul);
		dnciNewYork.establishTwoWayLink(dnciTokyo);
		dnciParis.establishTwoWayLink(dnciPune);
		dnciParis.establishTwoWayLink(dnciSaoPaulo);
		dnciParis.establishTwoWayLink(dnciSeattle);
		dnciParis.establishTwoWayLink(dnciSeoul);
		dnciParis.establishTwoWayLink(dnciTokyo);
		dnciSaoPaulo.establishTwoWayLink(dnciSeoul);
		dnciSaoPaulo.establishTwoWayLink(dnciTokyo);
		dnciSeattle.establishTwoWayLink(dnciSeoul);
		dnciSeattle.establishTwoWayLink(dnciTokyo);
		dnciSeoul.establishTwoWayLink(dnciTokyo);

		for (j = 0; j < dynArrCityInfoObj.size(); j++) {
			System.out.println("***");
			DataNode<CityInfo> dnCur = dynArrCityInfoObj.get(j);
			CityInfo ciCur = dnCur._objData;
			System.out.print(ciCur);
			System.out.println(" Connects to");

			for (int jLinked = 0; jLinked < dnCur._dynArrLinkedNode.size(); jLinked++) {
				DataNode<CityInfo> dnLinked = dnCur._dynArrLinkedNode.get(jLinked);
				CityInfo ciLinked = dnLinked._objData;
				Double qDist = ciCur.getDistance(ciLinked) + 0.5;
				long nDist = qDist.longValue();
				System.out.println("\t" + ciLinked + " Dist = " + nDist);
			}
		}
//		String[] arrStr = { "a", "b", "c" };
//		DataNode[] arrDNTest = new DataNode[arrStr.length];
//		for (j = 0; j < arrDNTest.length; j++) {
//			DataNode<String> dnTest = new DataNode<String>(arrStr[j]);
//			arrDNTest[j] = dnTest;
//		}
		Graph_CityInfo graph = new Graph_CityInfo(dynArrCityInfoObj);
		DynamicArray<DynamicArray<DataNode<CityInfo>>> dynadynaPaths = graph.computePaths(dnciPune._sUniqId,
				dnciParis._sUniqId, 3);
		ArrayList<TravelPath> lstTravelPath = new ArrayList<TravelPath>();
		for (j = 0; j < dynadynaPaths.size(); j++) {
			TravelPath tp = new TravelPath(dynadynaPaths.get(j));
			lstTravelPath.add(tp);
		}
		TravelPathComp_Distance pfnCompDist = new Tester().new TravelPathComp_Distance();
		Collections.sort(lstTravelPath, pfnCompDist);
		for (int jPath = 0; jPath < dynadynaPaths.size(); jPath++) {
			TravelPath tp = lstTravelPath.get(jPath);
			System.out.print("Distance = " + tp._qDist + " - ");
			DynamicArray<DataNode<CityInfo>> daci = tp._dynaCityInfo;
			for (j = 0; j < daci.size(); j++) {
				DataNode<CityInfo> dnT = daci.get(j);
				if (j != 0) {
					System.out.print(" -TO - ");
				}
				System.out.print(dnT._objData);
			}
			System.out.println();
		}
	}

	public class TravelPathComp_Distance implements Comparator<TravelPath> {

		@Override
		public int compare(TravelPath o1, TravelPath o2) {

			double qDiff = o1._qDist - o2._qDist;
			return qDiff == 0.0 ? 0 : ((qDiff < 0.0) ? -1 : 1);
		}

	}
}
