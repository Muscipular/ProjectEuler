using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProblemEuler.P1_25
{
    class P20 : IProblemRuner
    {
        private BigInteger Factorial(BigInteger c)
        {
            return c.CompareTo(1) <= 0 ? 1 : Factorial(c - 1) * c;
        }

        public void Run()
        {
            var s = Factorial(100).ToString();
            var sum = s.Sum(x => x - '0');
            Console.WriteLine(sum);
        }
    }
}
