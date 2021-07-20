/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gadreconsulting.math;

import java.util.Arrays;

/**
 *
 * @author gadre
 */
public class Matrix {

    private static final double __qPrecision = 1.0E-8;

    private static void multiplyRow(double[][] aaqVal, int jRow, double q) {
        for (int jC = 0; jC < aaqVal[jRow].length; jC++) {
            aaqVal[jRow][jC] *= q;
        }
    }

    private static void swapRows(double[][] aaqVal, int jRow1, int jRow2) {
        double[] aqTemp = aaqVal[jRow1];
        aaqVal[jRow1] = aaqVal[jRow2];
        aaqVal[jRow2] = aqTemp;
    }

    private double[][] _aaqVal = null;

    public Matrix(double[][] aaqVal) {

        int jRowCount = aaqVal.length;
        int jColumnCount = aaqVal[0].length;
        for (int jRow = 1; jRow < jRowCount; jRow++) {
            double[] aq = aaqVal[jRow];
            if (aq.length != jColumnCount) {
                throw new RuntimeException("Matrix must be rectangular");
            }
        }
        _aaqVal = aaqVal;
    }

    public double getDetereminant() {
        int jRowCount = _aaqVal.length;
        int jColumnCount = _aaqVal[0].length;
        if (jRowCount != jColumnCount) {
            throw new RuntimeException("Matrix must be square");
        }
        double qRet = 0.0;

        for (int jC = 0; jC < jColumnCount; jC++) {
            double qTemp = 1.0;
            for (int jR = 0; jR < jRowCount; jR++) {
                int jCAdj = (jC + jR) % jColumnCount;
                qTemp *= _aaqVal[jR][jCAdj];
            }
            qRet += qTemp;
        }
        for (int jC = 0; jC < jColumnCount; jC++) {
            double qTemp = 1.0;
            for (int jR = jRowCount - 1; jR >= 0; jR--) {
                int jCAdj = (jC + jRowCount - 1 - jR) % jColumnCount;
                qTemp *= _aaqVal[jR][jCAdj];
            }
            qRet -= qTemp;
        }
        return qRet;
    }

    private int compareDoubles(double q1, double q2) {
        int jRet = 0;
        double qDiff = q1 - q2;
        double qDiffAbs = Math.abs(qDiff);
        if (qDiffAbs > __qPrecision) {
            jRet = qDiffAbs > 0 ? 1 : -1;
        }
        return jRet;

    }

    public double[][] getInverse() {
        double[][] aaqRet = null;
        double qDeterminant = getDetereminant();
        if (compareDoubles(qDeterminant, 0.0) != 0) {
            aaqRet = computeInverse();

        }
        return aaqRet;
    }

    private double[][] computeInverse() {
        int jRowCount = _aaqVal.length;
        int jColumnCount = _aaqVal[0].length;
        double[][] aaqVal = cloneMatrixValues();
        double[][] aaqRet = getIdentityMatrix(_aaqVal.length);
        for (int jPivot = 0; jPivot < jColumnCount; jPivot++) {

            int jPivotSwapRow = 0;
            while (compareDoubles(aaqVal[jPivot + jPivotSwapRow][jPivot], 0.0) == 0) {
                jPivotSwapRow++;
                if (jPivot + jPivotSwapRow == jRowCount) {
                    break;
                }
            }
            if (jPivot + jPivotSwapRow == jRowCount) {
                throw new RuntimeException("Unexpected");
            }
            if (jPivotSwapRow != 0) {
                swapRows(aaqVal, jPivot, jPivot + jPivotSwapRow);
                swapRows(aaqRet, jPivot, jPivot + jPivotSwapRow);

            }
            if (compareDoubles(aaqVal[jPivot][jPivot], 1.0) != 0) {
                multiplyRow(aaqRet, jPivot, 1.0 / aaqVal[jPivot][jPivot]);
                multiplyRow(aaqVal, jPivot, 1.0 / aaqVal[jPivot][jPivot]);

            }
            for (int j = 0; j < jRowCount - 1; j++) {
                int jRowToZeroOutCol = (jPivot + 1 + j) % jRowCount;
                double qMultiplier = -1.0 * aaqVal[jRowToZeroOutCol][jPivot];

                addRow(aaqVal, jPivot, jRowToZeroOutCol, qMultiplier);
                addRow(aaqRet, jPivot, jRowToZeroOutCol, qMultiplier);
            }
        }
        return aaqRet;
    }

    private double[][] getIdentityMatrix(int jOrder) {
        double[][] aaqRet = new double[jOrder][jOrder];
        while (jOrder > 0) {
            jOrder--;
            aaqRet[jOrder][jOrder] = 1.0;
        }
        return aaqRet;
    }

    private double[][] cloneMatrixValues() {

        double[][] aaqRet = new double[_aaqVal.length][];
        for (int i = 0; i < _aaqVal.length; i++) {
            aaqRet[i] = Arrays.copyOf(_aaqVal[i], _aaqVal[i].length);
        }
        return aaqRet;
    }

    private void addRow(double[][] aaqVal, int jRowSrc, int jRowTgt, double qMultiplier) {
        for (int j = 0; j < aaqVal.length; j++) {
            aaqVal[jRowTgt][j] += aaqVal[jRowSrc][j] * qMultiplier;
        }

    }

    public double[][] multiply(double[][] aaqValA, double[][] aaqValB) {

        double[][] aaqRet = null;
        if (aaqValA[0].length == aaqValB.length) {
            aaqRet = new double[aaqValA.length][aaqValB[0].length];
            double qVal;
            for (int jRow = 0; jRow < aaqRet.length; jRow++) {
                for (int jCol = 0; jCol < aaqRet[jRow].length; jCol++) {
                    qVal = 0;
                    for (int j = 0; j < aaqValB.length; j++) {
                        qVal += aaqValA[j][jCol] * aaqValB[jRow][j];
                        aaqRet[jRow][jCol] = qVal;
                    }
                }
            }
        }
        return aaqRet;
    }
}
