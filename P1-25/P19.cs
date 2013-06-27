using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemEuler.P1_25
{
    class P19 : IProblemRuner
    {
        public void Run()
        {
            int x = 0;
            Console.WriteLine(new DateTime(1900, 1, 1).DayOfWeek);
            for (int i = 1901; i <= 2000; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (new DateTime(i, j, 1).DayOfWeek == DayOfWeek.Sunday)
                    {
                        x++;
                    }
                }
            }
            Console.WriteLine(x);
        }
    }
}
