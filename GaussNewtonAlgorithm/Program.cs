﻿using System;

namespace GaussNewtonAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DMatrix testMat = new DMatrix(5);
            Console.WriteLine($"{testMat}");

            testMat.Fill(0.5);
            Console.WriteLine($"{testMat}");

            DMatrix addMat = testMat + testMat;
            Console.WriteLine($"Add: {addMat}");

            DMatrix subMat = testMat - testMat;
            Console.WriteLine($"Subtract: {subMat}");

            DMatrix I = DMatrix.Id(5);
            Console.WriteLine($"Id Matrix: {I}");

            double[,] data = new double[,]
            {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 5 },
                { 3, 4, 5, 6 }
            };

            DMatrix rectMat = new DMatrix(data);
            Console.WriteLine($"A: {rectMat}");
            rectMat.SwapRows(0, 2);
            Console.WriteLine($"rows 0 and 2 swapped: {rectMat}");
            DMatrix TMat = rectMat.Transpose();
            Console.WriteLine($"A^T: {TMat}");

            DMatrix multMat = TMat * rectMat;
            Console.WriteLine($"A^T * A: {multMat}");

            double trace = multMat.Trace();
            Console.WriteLine($"Trace(A^T * A) = {trace}");

            double[,] invData = new double[,]
            {
                { 1.0, 2.0, 3.0 },
                { 3.0, 2.0, 1.0 },
                { 2.0, 1.0, 3.0 }
            };

            DMatrix lupTest = new DMatrix(invData);
            (bool success, DMatrix LU, int[] P, int S) = lupTest.LUPDecompose();
            (_, double det) = lupTest.Det();
            (_, DMatrix inv) = lupTest.Invert();

            Console.WriteLine($"LUPMat: {lupTest}");
            Console.WriteLine($"LU: {LU}");
            Console.WriteLine($"P: {P}");
            Console.WriteLine($"S: {S}");
            Console.WriteLine($"Det: {det:F2}");
            Console.WriteLine($"Invert: {inv}");
        }
    }
}