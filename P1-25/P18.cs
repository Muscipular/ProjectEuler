using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProblemEuler.P1_25
{
    public class P18 : IProblemRuner
    {
        private const string Value = @"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        private class Node
        {
            public int Index { get; set; }
            public int Value { get; set; }
            public int Total { get; set; }
        }

        public void Run()
        {
            var values = GetValue().Split('\n').Select(x => x.Trim().Split(' ').Select(int.Parse).ToArray()).ToArray();
            var nodes = new List<Node>();
            nodes.Add(new Node() { Total = values[0][0], Value = values[0][0] });
            for (int i = 0; i < values.Length - 1; i++)
            {
                var parents = nodes;
                var needcut = (i + 1) % 8 == 0;

                int vg = -1;
                if (needcut)
                {
                    vg = parents.OrderByDescending(x => x.Total).Take(Math.Min(parents.Count, 200)).Min(x => x.Total);
                }
                nodes = new List<Node>();
                var v2 = values[i + 1];
                for (int j = 0; j < parents.Count; j++)
                {
                    var p = parents[j];
                    if (needcut && p.Total < vg)
                    {
                        continue;
                    }
                    if (nodes.Count > 100000)
                    {
                        throw new Exception();
                    }
                    nodes.Add(new Node() { Total = p.Total + v2[p.Index], Value = v2[p.Index], Index = p.Index });
                    nodes.Add(new Node() { Total = p.Total + v2[p.Index + 1], Value = v2[p.Index + 1], Index = p.Index + 1 });
                }
            }
            var max = nodes.Max(x => x.Total);
            Console.WriteLine(max);
        }

        protected virtual string GetValue()
        {
            return Value;
        }
    }
}
