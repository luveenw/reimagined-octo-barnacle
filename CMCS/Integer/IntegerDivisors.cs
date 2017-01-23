using System;
using System.Collections.Generic;

namespace CMCS.Integer
{
    public class IntegerDivisors
    {
        /// <summary>
        /// Returns a list of positive integers that divide the specified positive integer. Returns
        /// an empty list if the specified number is not positive.
        /// </summary>
        /// <param name="number">The number for which to find positive divisors.</param>
        public List<int> DivisorsOf(int number)
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