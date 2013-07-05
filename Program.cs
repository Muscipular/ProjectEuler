using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProblemEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = int.Parse(args[0]);
            var runer = ProblemFactory.CreateProblem(i);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            runer.Run();
            stopwatch.Stop();
            Console.WriteLine("run time: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
