using System;
using System.Collections.Generic;
using static Program.FunctionHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program
{
    class Program
    {

            static void Main(string[] args)
            {
            var a = new Variable("a");

            var b = new Variable("b");

            var expr0 = new Multiplication(new Sum(a, b), new MSin(new Division(a, new Constant(2))));
            //var expr = FunctionHelper.Sin(a);
                var f = 7 * Math.PI / 2;
            var expr = ((a + b)* Sin(7 * Math.PI /2)).DiffExpr();
            Console.WriteLine(expr.ToString());

            Console.WriteLine(expr);

            Console.WriteLine(expr.Compute(new Dictionary<string, double> { ["a"] = 2, ["b"] = 2 }));
            Console.ReadKey();
        }
    }
}

