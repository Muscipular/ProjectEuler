using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = int.Parse(args[0]);
            ProblemFactory.CreateProblem(i).Run();
            Console.ReadKey();
        }
    }
}
