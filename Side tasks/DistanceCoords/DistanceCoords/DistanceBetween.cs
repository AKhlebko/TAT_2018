using System.Collections.Generic;

namespace DistanceCoords
{
    public class PairOfVectors
    {
        private List<double> Vec1;
        private List<double> Vec2;
        public delegate double DistanceDelegate(List<double> vec1, List<double> vec2);

        public PairOfVectors(List<double> vec1, List<double> vec2)
        {
            this.Vec1 = vec1;
            this.Vec2 = vec2;
        }

        public double GetDistance(DistanceDelegate function)
        {
            return function(Vec1, Vec2);
        }
    }
}