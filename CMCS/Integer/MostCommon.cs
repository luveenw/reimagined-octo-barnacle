using System.Linq;

namespace CMCS.Integer
{
    public class MostCommon
    {
        /// <summary>
        /// Find the most commonly occurring integers in the specified integer array.
        /// </summary>
        /// <param name="arr">The integer array in which to find the most commonly occurring values.</param>
        /// <returns>An integer array containing the most commonly occurring values.</returns>
        public static int[] FindMostCommonIn(int[] arr)
        {
            if (arr.Length == 0)
            {
                return arr;
            }

            var counts = arr.GroupBy(i => i).ToList();
            var maxCount = counts.Max(group => group.Count());

            return counts
                .Where(group => group.Count() == maxCount)
                .Select(group => group.Key)
                .ToArray();
        }
    }
}