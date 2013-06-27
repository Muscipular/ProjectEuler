using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProblemEuler
{
    public static class ProblemFactory
    {
        private static Type[] __Types = Assembly.GetExecutingAssembly().GetTypes();

        public static IProblemRuner CreateProblem(int problemId)
        {
            var className = "P" + problemId;
            var type = __Types.FirstOrDefault(x => x.Name == className);
            return type.GetConstructors().First().Invoke(new object[0]) as IProblemRuner;
        }
    }
}
