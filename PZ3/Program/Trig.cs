using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Program
{
    public class MTg : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            var radian = arg * Math.PI / 180;
            return Math.Tan(radian);
        }
        public MTg(Expr e) : base(e)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() / new MPow(new MCos(_arg), 2);
        }

        public override string ToString() => $"Tg({_arg.ToString()})";
    }
    public class MCos : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            var radian = arg * Math.PI / 180;
            return Math.Cos(radian);
        }
        public MCos(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() * (-1) * new MSin(_arg);
        }
        public override string ToString() => $"Cos({_arg.ToString()})";

    }
    public class MSin : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            
            var arg = ComputeBase(variableValues);
            if(arg % Math.PI / 4 == 0|| arg % Math.PI / 3 == 0)
                return Math.Sin(arg);
            else
            {
                var radian = arg * Math.PI / 180;
                return Math.Sin(radian);
            }

        }
        public MSin(Expr e) : base(e)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _arg.DiffExpr()  * new MCos(_arg);
        }
        //public override string ToString() => $"Sin({_arg.ToString()})";
        public override string ToString() => $"({new MSin(_arg).Compute().ToString()})";
    }
    public class MCtg : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            var radian = arg * Math.PI / 180;
            return 1 / Math.Tan(radian);
        }
        public MCtg(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return (-1)*_arg.DiffExpr() / new MPow(new MSin(_arg), 2);
        }
        public override string ToString() => $"Ctg({_arg.ToString()})";

    }
    public class Marcsin : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Asin(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Marcsin(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Marcctg : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.PI / 2 - Math.Atan(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Marcctg(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Marccos : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Acos(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Marccos(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }
    public class Marctg : Function
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            var arg = ComputeBase(variableValues);
            return Math.Atan(arg);
        }

        public override Expr DiffExpr()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Marctg(Expr arg) : base(arg)
        {
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
    }

}
