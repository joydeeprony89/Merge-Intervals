using System;
using System.Collections.Generic;
using System.Linq;

namespace Merge_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][] { new int[]{ 1, 3 }, new int[]{ 8, 10 }, new int[] { 15, 18 }, new int[] { 2, 6 } };
            var result = Merge(intervals);
            foreach(var res in result)
            {
                Console.WriteLine("[" + res[0] + " , " + res[1] + "]");
            }
        }

        static int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            Array.Sort(intervals, (n1, n2) => n1[0].CompareTo(n2[0]));
            int start = 0;
            int end = 0;
            int j = 0;
            while (j < intervals.Length)
            {
                start = intervals[j][0];
                end = intervals[j][1];
                j++;
                while (j < intervals.Length && intervals[j][0] <= end)
                {
                    end = Math.Max(end, intervals[j][1]);
                    j++;
                }
                result.Add(new int[] { start, end });
            }
            return result.ToArray();
        }
    }
}
