using System;
using System.Collections.Generic;
using System.Linq;

namespace Merge_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][] { new int[]{ 1, 9 }, new int[]{ 2, 5 }, new int[] { 19, 20 }, new int[] { 10, 11 },
                                             new int[]{ 12, 20 }, new int[]{ 0, 3 }, new int[] { 0, 1 }, new int[] { 0, 2 }};
            var result = SortAndMerge(intervals);
            foreach(var res in result)
            {
                Console.WriteLine("[" + res[0] + " , " + res[1] + "]");
            }
        }

        //static int[][] Merge(int[][] intervals)
        //{
        //    List<int[]> result = new List<int[]>();
        //    Array.Sort(intervals, (n1, n2) => n1[0].CompareTo(n2[0]));
        //    int start = 0;
        //    int end = 0;
        //    int j = 0;
        //    while (j < intervals.Length)
        //    {
        //        start = intervals[j][0];
        //        end = intervals[j][1];
        //        j++;
        //        while (j < intervals.Length && intervals[j][0] <= end)
        //        {
        //            end = Math.Max(end, intervals[j][1]);
        //            j++;
        //        }
        //        result.Add(new int[] { start, end });
        //    }
        //    return result.ToArray();
        //}

        static int[][] SortAndMerge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            LinkedList<int[]> mapper = new LinkedList<int[]>();
            foreach(int[] interval in intervals)
            {
                if(mapper.Count == 0 || mapper.Last()[1] < interval[0])
                {
                    mapper.AddLast(interval);
                }

                mapper.Last()[1] = Math.Max(mapper.Last()[1], interval[1]);
            }

            return mapper.ToArray();
        }
    }
}
