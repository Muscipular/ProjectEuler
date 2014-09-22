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
            var numbers = new HashSet<short>();
            //            numbers.Add(12, 16);
            for (short i = 2; i <= 28123; i++)
            {
                var pKey = (short)(i >> 1);
                if ((i & 1) == 0 && numbers.Contains(pKey))
                {
                    numbers.Add(i);
                    continue;
                }
                int sum1 = 1, v = i;
                for (int j = 2; j <= v / 2; j++)
                {
                    if (v % j == 0) sum1 += j;
                }
                if (sum1 <= v)
                {
                    continue;
                }
                numbers.Add(i);
            }
            short[] nList = numbers.OrderBy(x => x).ToArray();
            int sum = 0;
            for (short i = 1; i <= 28123; i++)
            {
                if (i < nList[0])
                {
                    sum += i;
                    continue;
                }
                int uIndex = 0;
                bool add = false;
                foreach (var s in nList)
                {
                    if (s > i / 2)
                    {
                        add = true;
                        break;
                    }
                    if (numbers.Contains((short)(i - s)))
                    {
                        break;
                    }
                }
                if (add)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
