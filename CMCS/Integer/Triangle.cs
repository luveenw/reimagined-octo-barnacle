using System;
using System.Collections.Generic;
using CMCS.Integer.Exception;

namespace CMCS.Integer
{
    public class Triangle
    {
        // Number of sides in a triangle.
        private const int NumSides = 3;

        // Precision (number of digits after decimal point) for returned results.
        private const int Precision = 3;

        /// <summary>
        /// Returns the area of the triangle formed by the specified sides, if they form a valid triangle.
        /// </summary>
        /// <param name="a">One side of the triangle. Must be non-zero, positive.</param>
        /// <param name="b">Another side of the triangle. Must be non-zero, positive.</param>
        /// <param name="c">Another side of the triangle. Must be non-zero, positive.</param>
        /// <exception cref="T:CMCS.Integer.InvalidTriangleException">
        /// If one of <paramref name="a"/>, <paramref name="b"/>, or <paramref name="c"/> is zero or negative.</exception>
        /// <exception cref="T:CMCS.Integer.InvalidTriangleException">If <paramref name="a"/>, <paramref name="b"/>,
        ///  and <paramref name="c"/> do not form a valid triangle.</exception>
        public static double CalculateArea(int a, int b, int c)
        {
            Validate(a, b, c);

            double s = (a + b + c) / 2.0;

            return Math.Round(Math.Sqrt(s * (s - a) * (s - b) * (s - c)), Precision);
        }

        // Protected for testing purposes.
        protected static void Validate(int a, int b, int c)
        {
            var sides = new List<int>(new[] {a, b, c});

            for (int i = 0; i < NumSides; i++)
            {
                if (sides[i] <= 0)
                {
                    throw new InvalidTriangleException(sides[i]);
                }
            }

            if (a > b + c || b > c + a || c > a + b)
            {
                throw new InvalidTriangleException(a, b, c);
            }
        }
    }
}