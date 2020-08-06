using System;
using System.Collections.Generic;

namespace Pivots
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>() { 2, 7, 4, 9, 10, 3, 12, 1, 15, 5, 11 };

            List<int> result = Pivots3Median(test);
        }


        static List<int> Pivots3Median(List<int> a)
        {
            List<int> pivots = new List<int>();
            GetPivot(a, pivots);
            return pivots;
        }

        static void GetPivot(List<int> a, List<int> pivots)
        {
            if (a.Count < 3)
                return;

            int first = a[0];
            int second = a[a.Count / 2];
            int third = a[a.Count - 1];

            if ((second < first && first < third) || (third < first && first < second))
            {
                pivots.Add(first);
                GetPivot(a.GetRange(1, a.Count - 1), pivots);
            }
            else if ((first < second && second < third) || (third < second && second < first))
            {
                pivots.Add(second);
                GetPivot(a.GetRange(0, a.Count / 2), pivots);
                GetPivot(a.GetRange(a.Count / 2 + 1, a.Count - a.Count / 2 - 1), pivots);
            }
            else
            {
                pivots.Add(third);
                GetPivot(a.GetRange(0, a.Count - 1), pivots);
            }
        }
    }
}
