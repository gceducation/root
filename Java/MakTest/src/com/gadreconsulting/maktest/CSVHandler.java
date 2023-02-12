package com.gadreconsulting.maktest;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class CSVHandler {

	private static final char __chComma = ',';
	private static final char __chDQ = '"';
	private static final String __sComma = "" + __chComma;
	private static final String __sDQ = "" + __chDQ;
	private static final String __sDQ2 = "" + __chDQ + __chDQ;

	public static String getCSVLine(List<String> lstStr) {
		String sRet = null;
		StringBuilder sb = new StringBuilder();
		for (int j = 0; j < lstStr.size(); j++) {
			String sTemp = lstStr.get(j);
			if (sTemp.contains(__sDQ)) {
				sTemp = sTemp.replace(__sDQ, __sDQ2);
			}
			boolean fHadComma = false;
			if (sTemp.contains(__sComma)) {
				fHadComma = true;
				sb.append(__chDQ);
			}
			sb.append(sTemp);
			if (fHadComma) {
				sb.append(__chDQ);
			}
			if (j <= lstStr.size() - 1) {
				sb.append(__chComma);
			}
		}
		sRet = sb.toString();
		return sRet;
	}

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		Path pathCSV = Paths.get("c:/scratch/data.csv");
		List<String> lstStrCSV = Files.readAllLines(pathCSV);
		for (int j = 0; j < lstStrCSV.size(); j++) {
			String s = lstStrCSV.get(j);
			List<String> lstStrParts = parseCSVLine(s);
			for (int i = 0; i < lstStrParts.size(); i++) {
				System.out.println(lstStrParts.get(i));
			}
			String sCSV = getCSVLine(lstStrParts);
			System.out.println("---");
			System.out.println(sCSV);
			System.out.println("---");
		}
		System.out.println("END OF FILE");
		
		
	}

	public static List<String> parseCSVLine(String s) {
		String[] asParts = s.split(",");
		ArrayList<String> lstStrParts = new ArrayList<String>();
		for (int iPart = 0; iPart < asParts.length; iPart++) {
			String sCurPart = asParts[iPart];
			if (sCurPart.length() > 0) {
				char chStart = sCurPart.charAt(0);
				if (chStart == __chDQ) {
					if (sCurPart.charAt(sCurPart.length() - 1) == __chDQ) {
						lstStrParts.add(sCurPart.substring(1, sCurPart.length() - 1));
					} else {
						boolean fFoundMatchingDQ = false;
						StringBuilder sb = new StringBuilder();
						sb.append(sCurPart);

						do {
							if (iPart + 1 < asParts.length) {
								iPart++;
								sb.append(',');
								sb.append(asParts[iPart]);

								if (asParts[iPart].charAt(asParts[iPart].length() - 1) == __chDQ) {
									if (asParts[iPart].length() > 2) {
// This is the case where enclosed double quote i.e. "" is followed by a comma
										if (asParts[iPart].charAt(asParts[iPart].length() - 2) == __chDQ) {

											fFoundMatchingDQ = false;
										} else {
											fFoundMatchingDQ = true;
										}
									} else {
										fFoundMatchingDQ = true;
									}
								}
								if (fFoundMatchingDQ) {
									break;
								}
							}
						} while (iPart < asParts.length);
						if (!fFoundMatchingDQ) {
							throw new RuntimeException("no matching DQ");
						} else {
							// Now remove the quotes surrounding it
							String sTemp = sb.toString();
							sTemp = sTemp.substring(1, sTemp.length() - 1);
							// now remove any dbldblquotes and replace with a doublequote
							sTemp = sTemp.replace(__sDQ2, __sDQ);
							lstStrParts.add(sTemp);

						}
					}
				} else {
					lstStrParts.add(sCurPart);
				}
			} else {
				lstStrParts.add(sCurPart);
			}
		}
		return lstStrParts;
	}
}
