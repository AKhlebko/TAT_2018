using System;

namespace Task2
{
    /// <summary>
    /// Class calculates area of a rectangle
    /// </summary>
    public class AreaCalculator
    {
        private double a;
        private double b;

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Sides can't be negative or zero.");
                }
                else
                {
                    b = value;
                }
            }
        }

        public double B
        {   
            get { return b; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Sides can't be negative or zero.");
                }
                else
                {
                    b = value;
                }
            }
        }

        public AreaCalculator(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides can't be negative or zero.");
            }
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Clculates area and returns it
        /// </summary>
        /// <returns>
        /// Returns calculated area
        /// </returns>
        public double GetArea()
        {
            return a * b;
        }
    }
}
