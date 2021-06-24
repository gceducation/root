package com.gadreconsulting.maktest;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Prime {

	public static void main(String[] args) throws IOException {
		
		ArrayList<String> alStr = new ArrayList();
		
		
		
		
		
		int n = -99;
		int[] arrFact = getPrimeFactors(n);

		for (int j = 0; j < arrFact.length; j++) {

			System.out.println(arrFact[j]);
			if ((arrFact[j] == 1) || (arrFact[j] == 0)) {
				break;
			}
		}
		boolean fVerification = fVerifyFactors(n, arrFact);
		System.out.println(fVerification ? "OK" : "ERROR");

		int n1 = 999;
		int n2 = 9999;
		//int nGCD = gcdFactorMethod(n1, n2);
		//int nGCD = gcdEuclidAlgoIterative(n1, n2);
		int nGCD = gcdEuclidAlgoRecursive(n1, n2);
		System.out.println("GCD of " + n1 + " and " + n2 + " = " + nGCD);
		System.out.println();
		System.out.println("End. Press Enter to Exit");
		System.in.read();
	}

	private static boolean fVerifyFactors(int n, int[] arrFact) {
		int nMulti = 1;
		for (int j = 0; j < arrFact.length; j++) {
			nMulti *= arrFact[j];
			if ((arrFact[j] == 1) || (arrFact[j] == 0)) {
				break;
			}
		}
		return nMulti == n;
	}

	private static int gcdEuclidAlgoIterative(int n1, int n2) {
		int nTemp = 0;
		if (n1 < 0) {
			n1 = -n1;
		}
		if (n2 < 0) {
			n2 = -n2;
		}
		do {
			nTemp = n1 % n2;
			if (nTemp > 0) {
				n1 = n2;
				n2 = nTemp;
			}
		} while (nTemp > 0);

		return n2;

	}
	private static int gcdEuclidAlgoRecursive(int n1, int n2) {
		if (n1 < 0) {
			n1 = -n1;
		}
		if (n2 < 0) {
			n2 = -n2;
		}
		return getGCDWithEuclidMethodRecursiveInternal(n1, n2);
	}

	private static int gcdFactorMethod(int n1, int n2) {
		if (n1 < 0) {
			n1 = -n1;
		}
		if (n2 < 0) {
			n2 = -n2;
		}
		int nRet = 1;
		int[] arrFact1 = getPrimeFactors(n1);
		int[] arrFact2 = getPrimeFactors(n2);
		int[] arrFactCommon = new int[Integer.SIZE];
		int jFactCommon = 0;
		for (int j1 = 0; j1 < arrFact1.length; j1++) {
			int nCurFact1 = arrFact1[j1];
			if ((nCurFact1 == 1) || (nCurFact1 == 0)) {
				break;
			}
			for (int j2 = 0; j2 < arrFact2.length; j2++) {
				if ((arrFact2[j2] == 1) || (arrFact2[j2] == 0)) {
					break;
				}
				if (arrFact2[j2] != -1) {
					if (nCurFact1 == arrFact2[j2]) {
						arrFact2[j2] = -1;
						arrFactCommon[jFactCommon] = nCurFact1;
						jFactCommon++;
						break;
					}
				}
			}
		}
		if (jFactCommon == 0) {
			nRet = 1;
		} else {
			for (int jTemp = 0; jTemp < jFactCommon; jTemp++) {
				nRet = nRet * arrFactCommon[jTemp];
			}
		}
		return nRet;
	}


	private static int getGCDWithEuclidMethodRecursiveInternal(int n1, int n2) {
		int nRet = n1 % n2;
		if (nRet == 0) {
			nRet = n2;
		} else {
			nRet = getGCDWithEuclidMethodRecursiveInternal(n2, nRet);
		}
		return nRet;
	}

	static int[] getPrimeFactors(int n) {
		int[] ajFactors = new int[Integer.SIZE];
		if (n == 0) {
			ajFactors[0] = 0;
			ajFactors[1] = -1;
		} else {
			int jFactorsFilled = 0;
			if (n < 0) {
				ajFactors[0] = -1;
				n = -n;
				jFactorsFilled = 1;
			}
			if (n < 3) {
				ajFactors[jFactorsFilled] = n;
				jFactorsFilled++;
				ajFactors[jFactorsFilled] = 1;

			} else {
				int jFact;
				int nOriginal = n;
				for (jFact = 2; jFact <= 3; jFact++) {
					while (n % jFact == 0) {
						ajFactors[jFactorsFilled] = jFact;
						jFactorsFilled++;
						n = n / jFact;
					}
				}
				jFact = 5;
				int jIncrement = 2;
				while (jFact * jFact <= n) {
					while (n % jFact == 0) {
						ajFactors[jFactorsFilled] = jFact;
						jFactorsFilled++;
						n = n / jFact;
					}
					jFact += jIncrement;
					jIncrement = 6 - jIncrement;
				}
				ajFactors[jFactorsFilled] = n;
				if (n > 1) {
					jFactorsFilled++;
					ajFactors[jFactorsFilled] = 1;
				}
			}
		}

		return ajFactors;
	}

}
