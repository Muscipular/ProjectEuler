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
            var i = 1;
            var sum = names.Sum(x => x.Sum(a => a - 'A' + 1) * i++);
            Console.WriteLine(sum);
        }
    }
}
