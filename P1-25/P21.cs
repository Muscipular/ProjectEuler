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
                List<int> p = new List<int>();
                for (int j = 1; j <= i / 2; j++)
                {
                    if (i % j != 0)
                    {
                        continue;
                    }
                    p.Add(j);
                }
                int x = p.Sum();
                if (i == x)
                {
                    continue;
                }
                p.Clear();
                for (int j = 1; j <= x / 2; j++)
                {
                    if (x % j != 0)
                    {
                        continue;
                    }
                    p.Add(j);
                }
                if (p.Sum() == i)
                {
                    Amicable amicable = new Amicable() { A = i, B = x };
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
