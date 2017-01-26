using System;
using System.Collections.Generic;

namespace CMCS.Integer
{
    public class IntegerDivisors
    {
        /// <summary>
        /// Determine the divisors of the specified integer.
        /// </summary>
        /// <param name="number">The number for which to find positive divisors.</param>
        /// <returns>A list of positive integers that divide <paramref name="number"/>, if it is positive. Otherwise,
        /// returns an empty list.</returns>
        public static List<int> DivisorsOf(int number)
        {
            var result = new List<int>();

            if (number <= 0)
            {
                return result;
            }

            result.Add(1);

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result.Add(i);
                    result.Add(number / i);
                }
            }

            if (number > 1)
            {
                result.Add(number);
            }

            return result;
        }
    }
}