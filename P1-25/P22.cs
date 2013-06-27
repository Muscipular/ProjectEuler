using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProblemEuler.Properties;

namespace ProblemEuler.P1_25
{
    class P22 : IProblemRuner
    {
        public void Run()
        {
            var names = Resources.P22_names.Split(',').Select(x => x.Trim('"')).ToList();
            names.Sort();
            var names2 = names.Select(x => new { Sum = x.Sum(xx => xx - 'A' + 1), Value = x }).ToArray();
            var i = 1;
            var sum = 0;
            foreach (var x in names2)
            {
                sum += x.Sum * i++;
            }
            Console.WriteLine(sum);
        }
    }
}
