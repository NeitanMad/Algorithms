using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithms.Lesson_3
{
     public class PointBenchmark
    {
        public static string LessonName = "3. HomeWork_Lesson_3";

        public class BenchmarkForClassAndStruct
        {
            public struct PointStruct
            {
                public double X;
                public double Y;
            }

            public class PointClass
            {
                public double X;
                public double Y;
                public static double res;

            }

            public static int SizeArray = 100000; // Размер массивов

            public static PointClass[] pointClasses = new PointClass[SizeArray + 1]; // Массив типа PointClass
            public static PointStruct[] pointStructs = new PointStruct[SizeArray + 1]; // Массив типа PointStruct

            [Benchmark]
            public void ArrayPointsClass() // Заполнение массива PointClass случайными числами и вычисление расстояния
            {

                Random rnd = new Random();

                for (int i = 0; i < SizeArray + 1; i++)
                {
                    pointClasses[i] = new PointClass();
                    pointClasses[i].X = rnd.NextDouble();
                    pointClasses[i].Y = rnd.NextDouble();
                }

                for (int i = 0; i < SizeArray; i++)
                {
                    PointDistanceClass(pointClasses[0], pointClasses[i]);
                }
            }

            [Benchmark]
            public void ArrayPointsStruct() // Заполнение массива PointStruct случайными числами и вычисление расстояния
            {
                Random rnd = new Random();

                for (int i = 0; i < SizeArray + 1; i++)
                {
                    pointStructs[i] = new PointStruct();
                    pointStructs[i].X = rnd.NextDouble();
                    pointStructs[i].Y = rnd.NextDouble();
                }

                for (int i = 0; i < SizeArray; i++)
                {
                    PointDistanceStruct(pointStructs[0], pointStructs[i]);
                }
            }

            public static double PointDistanceClass(PointClass point1, PointClass point2) // Расстояние между точками для PointClass
            {
                double x = point1.X - point2.X;
                double y = point1.Y - point2.Y;

                return Math.Sqrt((x * x) + (y * y));
            }

            public static double PointDistanceStruct(PointStruct point1, PointStruct point2) // Расстояние между точками для PointStruct
            {
                double x = point1.X - point2.X;
                double y = point1.Y - point2.Y;

                return Math.Sqrt((x * x) + (y * y));
            }

        }
    }
}
