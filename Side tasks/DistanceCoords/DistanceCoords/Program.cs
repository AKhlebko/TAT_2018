using System;
using System.Collections.Generic;

namespace DistanceCoords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Vec1 = new List<double>
                (
                new double[] { 1, 1, 1, 1 }
                );
            List<double> Vec2 = new List<double>
                (
                new double[] { 1, 1, 1, 1 }
                );
            PairOfVectors distanceBetweenCounter = new PairOfVectors(Vec1, Vec2);
            Console.WriteLine(distanceBetweenCounter.GetDistance(GetDistance));
        }

        public static double GetDistance(List<double> vec1, List<double> vec2)
        {
            double response = 0;
            for (int i = 0; i < vec1.Count; i++)
            {
                response += (vec1[i] - vec2[i]) * (vec1[i] - vec2[i]);
            }
            return Math.Sqrt(response);
        }
    }
}
