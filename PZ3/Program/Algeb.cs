using System;
using System.Collections.Generic;
namespace Program
{
    class Sum : BinaryOperation
    {
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _expr1.DiffExpr() + _expr2.DiffExpr();
        }

        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _expr1.Compute(variableValues) + _expr2.Compute(variableValues);
        }

        public override string ToString() => $"({_expr1.ToString()} + {_expr2.ToString()})";

        public Sum(Expr e1, Expr e2) : base(e1, e2)
        {
        }

    }
    class Subtraction : BinaryOperation
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _expr1.Compute(variableValues) - _expr2.Compute(variableValues);
        }
        public Subtraction(Expr e1, Expr e2) : base(e1, e2)
        {

        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _expr1.DiffExpr() - _expr2.DiffExpr();
        }
        public override string ToString() => $"({_expr1.ToString()} - {_expr2.ToString()})";
    }
    class Multiplication : BinaryOperation
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _expr1.Compute(variableValues) * _expr2.Compute(variableValues);
        }
        public Multiplication(Expr e1, Expr e2) : base(e1, e2)
        {

        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _expr1.DiffExpr() * _expr2 + _expr1 * _expr2.DiffExpr();
        }
        public override string ToString() => $"({_expr1.ToString()} * {_expr2.ToString()})";
    }
    class Division : BinaryOperation
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _expr1.Compute(variableValues) / _expr2.Compute(variableValues);
        }
        public Division(Expr e1, Expr e2) : base(e1, e2)
        {

        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            if(_expr2.IsConstant )
            {
                return  _expr1.DiffExpr() / _expr2;
            }
            return (_expr1.DiffExpr() * _expr2 - _expr1 * _expr2.DiffExpr()) / (_expr2 * _expr2);
        }
        public override string ToString() => $"({_expr1.ToString()} / {_expr2.ToString()})";
    }
    class Sqrt : UnaryOperation
    {
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            try
            {
                return Math.Sqrt(ComputeBase(variableValues));
            }
            catch
            {
                throw new Exception("Нельзя извлекать корень из отрицательного числа");
            }
        }

        public override string ToString() => $"({_expr.ToString()} ^ 2)";

        public Sqrt(Expr e) : base(e)
        {
        }

        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return (_expr.DiffExpr() / (new Constant(2) * ~(_expr)));
        }
    }

    public class MPow : Function
{
        private readonly Expr _e1;
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return Math.Pow(ComputeBase(variableValues), _e1.Compute(variableValues));
        }
        public MPow(Expr e, Expr e1) : base(e)
        {
            _e1 = e1;
        }
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {
            return _arg.DiffExpr() * _e1 * new MPow(_arg, _e1 - new Constant(1));
        }

        public override string ToString() => $"({_arg.ToString()} ^ {_e1})";
    }
}
