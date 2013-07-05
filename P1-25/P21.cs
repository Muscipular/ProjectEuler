using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemEuler.P1_25
{
    class P21 : IProblemRuner
    {
        private struct Amicable
        {
            public bool Equals(Amicable other)
            {
                return this == other;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is Amicable && Equals((Amicable)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (A * 397 + B) ^ (B * 15 + A);
                }
            }

            public int A, B;

            public static bool operator ==(Amicable a, Amicable b)
            {
                return (a.A == b.A && a.B == b.B) || (a.B == b.A && a.A == b.B);
            }

            public static bool operator !=(Amicable a, Amicable b)
            {
                return !(a == b);
            }
        }

        public void Run()
        {
            List<Amicable> list = new List<Amicable>();
            for (int i = 1; i < 10000; i++)
            {
                var sqrt = (int)Math.Sqrt(i);
                int sum1 = 1, sum2 = 1;
                for (int j = 2; j <= sqrt; j++)
                {
                    if (i % j != 0)
                    {
                        continue;
                    }
                    sum1 += j + i / j;
                }
                if (i <= sum1)
                {
                    continue;
                }
                var sqrt2 = (int)Math.Sqrt(sum1);
                for (int j = 2; j <= sqrt2; j++)
                {
                    if (sum1 % j != 0)
                    {
                        continue;
                    }
                    sum2 += j + sum1 / j;
                }
                if (sum2 == i)
                {
                    Amicable amicable = new Amicable() { A = i, B = sum1 };
                    if (!list.Contains(amicable))
                    {
                        list.Add(amicable);
                    }
                }
            }
            var sum = list.Sum(x => x.A + x.B);
            Console.WriteLine(sum);
        }
    }
}
