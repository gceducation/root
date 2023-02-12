package com.gadreconsulting.math.test;

import com.gadreconsulting.math.Matrix;

public class Tester {

    public static void main(String[] args) {
        double[][] aaqVal = new double[3][3];
        aaqVal[0][0] = 3;
        aaqVal[0][1] = 4;
        aaqVal[0][2] = 5;
        aaqVal[1][0] = 2	;
        aaqVal[1][1] = 2.0+2.0/3.0;
        aaqVal[1][2] = 3;
        aaqVal[2][0] = 3;
        aaqVal[2][1] = 16;
        aaqVal[2][2] = 2;

        Matrix matrix = new Matrix(aaqVal);
        double qDeterminant = matrix.getDetereminant();
        System.out.println("Matrix Determinant");
        System.out.println(qDeterminant);
        System.out.println("Original Matrix");
        printMatrixArray(aaqVal);
       double[][] aqInverse = matrix.getInverse();
         System.out.println("Inverted Matrix");
        printMatrixArray(aqInverse);
        double[][] aqVerif = matrix.multiply(aaqVal, aqInverse);

        System.out.println("Verification Matrix");
        printMatrixArray(aqVerif);

    }
private static final String __sFmt = "%15.8f";
    private static void printMatrixArray(double[][] aaqVal) {
        for (int jRow = 0; jRow < aaqVal.length; jRow++) {
            for (int jCol = 0; jCol < aaqVal[jRow].length; jCol++) {
                if (jCol != 0) {
                    System.out.print('\t');
                }
                System.out.print(String.format(__sFmt, aaqVal[jRow][jCol]));
            }
            System.out.println();
        }
    }
}
