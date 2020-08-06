using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxScore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>() { 0, -10, 100, -20 };

            int result = MaxScore(test);
        }

        static int MaxScore(List<int> cells)
        {
            List<int> steps = new List<int>();
            steps.Add(1);
            for (int i = 3; i < 10000; i += 10)
            {
                if (IsPrime(i))
                    steps.Add(i);
            }

            int[] solutions = new int[cells.Count];
            solutions[solutions.Length - 1] = cells[cells.Count - 1];

            for (int i = cells.Count - 2; i >= 0; i--)
            {
                List<int> options = new List<int>();
                foreach (var step in steps)
                {
                    if (step <= cells.Count - 1 - i)
                        options.Add(cells[i] + solutions[i + step]);
                }
                solutions[i] = options.Max();
            }

            return solutions[0];
        }

        static bool IsPrime(int number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;

            int boundary = (int)Math.Sqrt(number);
            for (int i = 2; i <= boundary; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }


    }
}
