package com.gadreconsulting.BinaryTree.Tester;

import com.gadreconsulting.BinaryTree.BinaryTree;
import com.gadreconsulting.BinaryTree.ETraversal;
import com.gadreconsulting.BinaryTree.IBBTreeTraversalCallback;

public class Tester {
	public static void main(String[] args) {

		CityInfo[] arrCityDummy = { //
				new CityInfo("A", 35.6897, 139.6922, "A", 37977000),
				new CityInfo("B", -6.2146, 106.8451, "B", 34540000),
				new CityInfo("C", 28.66, 77.23, "C", 29617000),
				new CityInfo("D", 18.9667, 72.8333, "D", 23355000),
				new CityInfo("E", 14.5958, 120.9772, "E", 23088000),
				new CityInfo("F", 31.1667, 121.4667, "F", 22120000),
//				new CityInfo("Tokyo", 35.6897, 139.6922, "Japan", 37977000),
//				new CityInfo("Jakarta", -6.2146, 106.8451, "Indonesia", 34540000),
//				new CityInfo("Delhi", 28.66, 77.23, "India", 29617000),
//				new CityInfo("Mumbai", 18.9667, 72.8333, "India", 23355000),
//				new CityInfo("Manila", 14.5958, 120.9772, "Philippines", 23088000),
//				new CityInfo("Shanghai", 31.1667, 121.4667, "China", 22120000),				
//				new CityInfo("Sao Paulo", -23.5504, -46.6339, "Brazil", 22046000),
//				new CityInfo("Seoul", 37.5833, 127, "Korea, South", 21794000),
//				new CityInfo("Mexico City", 19.4333, -99.1333, "Mexico", 20996000),
//				new CityInfo("Guangzhou", 23.1288, 113.259, "China", 20902000),
//				new CityInfo("Beijing", 39.905, 116.3914, "China", 19433000),
//				new CityInfo("Cairo", 30.0561, 31.2394, "Egypt", 19372000),
//				new CityInfo("New York", 40.6943, -73.9249, "United States", 18713220),
//				new CityInfo("Kolkata", 22.5411, 88.3378, "India", 17560000),
//				new CityInfo("Moscow", 55.7558, 37.6178, "Russia", 17125000),
//				new CityInfo("Bangkok", 13.75, 100.5167, "Thailand", 17066000),
//				new CityInfo("Buenos Aires", -34.5997, -58.3819, "Argentina", 16157000),
//				new CityInfo("Shenzhen", 22.535, 114.054, "China", 15929000),
//				new CityInfo("Dhaka", 23.7161, 90.3961, "Bangladesh", 15443000),
//				new CityInfo("Lagos", 6.45, 3.4, "Nigeria", 15279000),
//				new CityInfo("Istanbul", 41.01, 28.9603, "Turkey", 15154000),
//				new CityInfo("Osaka", 34.6936, 135.5019, "Japan", 14977000),
//				new CityInfo("Karachi", 24.86, 67.01, "Pakistan", 14835000),
//				new CityInfo("Bangalore", 12.9699, 77.598, "India", 13707000),
//				new CityInfo("Tehran", 35.7, 51.4167, "Iran", 13633000),
//				new CityInfo("Kinshasa", -4.3317, 15.3139, "Congo (Kinshasa)", 13528000),
//				new CityInfo("Ho Chi Minh City", 10.8167, 106.6333, "Vietnam", 13312000),
//				new CityInfo("Los Angeles", 34.1139, -118.4068, "United States", 12750807),
//				new CityInfo("Rio de Janeiro", -22.9083, -43.1964, "Brazil", 12272000),
//				new CityInfo("Nanyang", 32.9987, 112.5292, "China", 12010000),
//				new CityInfo("Chennai", 13.0825, 80.275, "India", 11324000),
//				new CityInfo("Chengdu", 30.6636, 104.0667, "China", 11309000),
//				new CityInfo("Lahore", 31.5497, 74.3436, "Pakistan", 11021000),
//				new CityInfo("Paris", 48.8566, 2.3522, "France", 11020000),
//				new CityInfo("London", 51.5072, -0.1275, "United Kingdom", 10979000),
//				new CityInfo("Linyi", 35.0606, 118.3425, "China", 10820000),
//				new CityInfo("Tianjin", 39.1467, 117.2056, "China", 10800000),
//				new CityInfo("Shijiazhuang", 38.0422, 114.5086, "China", 10784600),
//				new CityInfo("Baoding", 38.8671, 115.4845, "China", 10700000),
//				new CityInfo("Zhoukou", 33.625, 114.6418, "China", 9901000),
//				new CityInfo("Lima", -12.05, -77.0333, "Peru", 9848000),
//				new CityInfo("Hyderabad", 17.3667, 78.4667, "India", 9746000),
//				new CityInfo("Bogota", 4.6126, -74.0705, "Colombia", 9464000),
//				new CityInfo("Weifang", 36.7167, 119.1, "China", 9373000),
//				new CityInfo("Nagoya", 35.1167, 136.9333, "Japan", 9113000),
//				new CityInfo("Wuhan", 30.5872, 114.2881, "China", 8962000),
//				new CityInfo("Heze", 35.2333, 115.4333, "China", 8750000),
//				new CityInfo("Ganzhou", 25.8292, 114.9336, "China", 8677600),
//				new CityInfo("Tongshan", 34.261, 117.1859, "China", 8669000),
//				new CityInfo("Chicago", 41.8373, -87.6862, "United States", 8604203),
//				new CityInfo("Handan", 36.6116, 114.4894, "China", 8499000),
//				new CityInfo("Luanda", -8.8383, 13.2344, "Angola", 8417000),
//				new CityInfo("Fuyang", 32.8986, 115.8045, "China", 8360000),
//				new CityInfo("Kuala Lumpur", 3.1478, 101.6953, "Malaysia", 8285000),
//				new CityInfo("Jining", 35.4, 116.5667, "China", 8023000),
//				new CityInfo("Dongguan", 23.0475, 113.7493, "China", 7981000),
//				new CityInfo("Hanoi", 21.0245, 105.8412, "Vietnam", 7785000),
//				new CityInfo("Pune", 18.5196, 73.8553, "India", 7764000),
//				new CityInfo("Chongqing", 29.55, 106.5069, "China", 7739000),

		};

		CityInfo[] arrCity = { //
				new CityInfo("Tokyo", 35.6897, 139.6922, "Japan", 37977000),
				new CityInfo("Jakarta", -6.2146, 106.8451, "Indonesia", 34540000),
				new CityInfo("Delhi", 28.66, 77.23, "India", 29617000),
				new CityInfo("Mumbai", 18.9667, 72.8333, "India", 23355000),
				new CityInfo("Manila", 14.5958, 120.9772, "Philippines", 23088000),
				new CityInfo("Shanghai", 31.1667, 121.4667, "China", 22120000),
				new CityInfo("Sao Paulo", -23.5504, -46.6339, "Brazil", 22046000),
				new CityInfo("Seoul", 37.5833, 127, "Korea, South", 21794000),
				new CityInfo("Mexico City", 19.4333, -99.1333, "Mexico", 20996000),
				new CityInfo("Guangzhou", 23.1288, 113.259, "China", 20902000),
				new CityInfo("Beijing", 39.905, 116.3914, "China", 19433000),
				new CityInfo("Cairo", 30.0561, 31.2394, "Egypt", 19372000),
				new CityInfo("New York", 40.6943, -73.9249, "United States", 18713220),
				new CityInfo("Kolkata", 22.5411, 88.3378, "India", 17560000),
				new CityInfo("Moscow", 55.7558, 37.6178, "Russia", 17125000),
				new CityInfo("Bangkok", 13.75, 100.5167, "Thailand", 17066000),
				new CityInfo("Buenos Aires", -34.5997, -58.3819, "Argentina", 16157000),
				new CityInfo("Shenzhen", 22.535, 114.054, "China", 15929000),
				new CityInfo("Dhaka", 23.7161, 90.3961, "Bangladesh", 15443000),
				new CityInfo("Lagos", 6.45, 3.4, "Nigeria", 15279000),
				new CityInfo("Istanbul", 41.01, 28.9603, "Turkey", 15154000),
				new CityInfo("Osaka", 34.6936, 135.5019, "Japan", 14977000),
				new CityInfo("Karachi", 24.86, 67.01, "Pakistan", 14835000),
				new CityInfo("Bangalore", 12.9699, 77.598, "India", 13707000),
				new CityInfo("Tehran", 35.7, 51.4167, "Iran", 13633000),
				new CityInfo("Kinshasa", -4.3317, 15.3139, "Congo (Kinshasa)", 13528000),
				new CityInfo("Ho Chi Minh City", 10.8167, 106.6333, "Vietnam", 13312000),
				new CityInfo("Los Angeles", 34.1139, -118.4068, "United States", 12750807),
				new CityInfo("Rio de Janeiro", -22.9083, -43.1964, "Brazil", 12272000),
				new CityInfo("Nanyang", 32.9987, 112.5292, "China", 12010000),
				new CityInfo("Chennai", 13.0825, 80.275, "India", 11324000),
				new CityInfo("Chengdu", 30.6636, 104.0667, "China", 11309000),
				new CityInfo("Lahore", 31.5497, 74.3436, "Pakistan", 11021000),
				new CityInfo("Paris", 48.8566, 2.3522, "France", 11020000),
				new CityInfo("London", 51.5072, -0.1275, "United Kingdom", 10979000),
				new CityInfo("Linyi", 35.0606, 118.3425, "China", 10820000),
				new CityInfo("Tianjin", 39.1467, 117.2056, "China", 10800000),
				new CityInfo("Shijiazhuang", 38.0422, 114.5086, "China", 10784600),
				new CityInfo("Baoding", 38.8671, 115.4845, "China", 10700000),
				new CityInfo("Zhoukou", 33.625, 114.6418, "China", 9901000),
				new CityInfo("Lima", -12.05, -77.0333, "Peru", 9848000),
				new CityInfo("Hyderabad", 17.3667, 78.4667, "India", 9746000),
				new CityInfo("Bogota", 4.6126, -74.0705, "Colombia", 9464000),
				new CityInfo("Weifang", 36.7167, 119.1, "China", 9373000),
				new CityInfo("Nagoya", 35.1167, 136.9333, "Japan", 9113000),
				new CityInfo("Wuhan", 30.5872, 114.2881, "China", 8962000),
				new CityInfo("Heze", 35.2333, 115.4333, "China", 8750000),
				new CityInfo("Ganzhou", 25.8292, 114.9336, "China", 8677600),
				new CityInfo("Tongshan", 34.261, 117.1859, "China", 8669000),
				new CityInfo("Chicago", 41.8373, -87.6862, "United States", 8604203),
				new CityInfo("Handan", 36.6116, 114.4894, "China", 8499000),
				new CityInfo("Luanda", -8.8383, 13.2344, "Angola", 8417000),
				new CityInfo("Fuyang", 32.8986, 115.8045, "China", 8360000),
				new CityInfo("Kuala Lumpur", 3.1478, 101.6953, "Malaysia", 8285000),
				new CityInfo("Jining", 35.4, 116.5667, "China", 8023000),
				new CityInfo("Dongguan", 23.0475, 113.7493, "China", 7981000),
				new CityInfo("Hanoi", 21.0245, 105.8412, "Vietnam", 7785000),
				new CityInfo("Pune", 18.5196, 73.8553, "India", 7764000),
				new CityInfo("Chongqing", 29.55, 106.5069, "China", 7739000),

		};
		BinaryTree<CityInfo> bbTree = new BinaryTree<CityInfo>(false, false);

		TraverseCallback_Print tcbPrint = new TraverseCallback_Print();
		for (int j = 0; j < arrCityDummy.length; j++) {
			System.out.println("==============" + j);
			bbTree.put(arrCityDummy[j]);
			bbTree.traverseTree(ETraversal.InOrder, tcbPrint);

		}

		// bbTree.traverseTree(ETraversal.InOrder, tcbPrint);
		CityInfo ciForSearch = new CityInfo("Osaka", "Japan");
		CityInfo ciFound = bbTree.get(ciForSearch);
	}
}