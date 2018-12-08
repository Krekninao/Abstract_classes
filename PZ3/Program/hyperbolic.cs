using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Program
{
    public class Msinh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Sinh(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Msinh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mcosh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Cosh(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Mcosh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mtanh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Tanh(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Mtanh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mcoth : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return 1 / Math.Tanh(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Mcoth(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mrevcosh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Log(arg - Math.Sqrt(Math.Pow(arg,2) + 1));
        }

        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() / (new Sqrt(new MPow(_arg, 2) - 1));
        }

        public override string ToString()
        {
            return $"arccosh({_arg.ToString()})";
        }

        public Mrevcosh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mrevsinh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Log(arg - Math.Sqrt(Math.Pow(arg, 2) - 1));
        }

        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() / (new Sqrt(new MPow(_arg, 2) + 1));
        }

        public override string ToString()
        {
            return $"arcsinh({_arg.ToString()})";
        }


        public Mrevsinh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mrevtanh : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
           
            var arg = ComputeBase(variableValues);
            return 0.5*Math.Log((arg + 1)/ (1 - arg ));
        }

        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() / (1 - new MPow(_arg, 2) );
        }

        public override string ToString()
        {
            return $"arctanh({_arg.ToString()})";
        }


        public Mrevtanh(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Mrevcoth : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return 0.5 * Math.Log((arg + 1) / (arg - 1));
        }

        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() / (1 - new MPow(_arg, 2));
        }

        public override string ToString()
        {
            return $"arccoth({_arg.ToString()})";
        }


        public Mrevcoth(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
}