using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemEuler.P1_25
{
    class P23 : IProblemRuner
    {
        public void Run()
        {
            List<int> numbers = new List<int>(28123);
            int sum = 0;
            for (int i = 12; i <= 28123; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int v = numbers[i];
                int sum1 = 1;
                for (int j = 2; j <= v / 2; j++)
                {
                    if (v % j == 0) sum1 += j;
                }
                if (sum1 <= v)
                {
                    continue;
                }
                int v2 = v * 2;
                for (int j = v / 2 + 1; j <= v2 / 2; j++)
                {
                    if (v % j == 0) sum1 += j;
                }
                if (sum1 <= v2)
                {
                    Console.Write(v + ",  ");
                    sum += v;
                }
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
