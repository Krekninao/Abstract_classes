using System;
using System.Collections.Generic;

namespace Program
{
    public abstract class Expr
    {
        public abstract double Compute(IReadOnlyDictionary<string, double> variableValues = null);
        public abstract IEnumerable<string> Variables { get; protected set; }
        public abstract bool IsConstant { get; }
        public abstract bool IsPolynom { get; }

        public static Expr operator ~(Expr operand) => new Sqrt(operand);
        public static Expr operator +(Expr operand1, Expr operand2) => new Sum(operand1, operand2);
        public static Expr operator -(Expr operand1, Expr operand2) => new Subtraction (operand1, operand2);
        public static Expr operator /(Expr operand1, Expr operand2) => new Division(operand1, operand2);
        public static Expr operator *(Expr operand1, Expr operand2) => new Multiplication(operand1, operand2);
        public static implicit operator Expr(double d) => new Constant(d);
        public abstract Expr DiffExpr();
        public abstract override string ToString();
    }
    public static class FunctionHelper
    {
        public static Expr Pow(Expr arg1, Expr arg2) => new MPow(arg1, arg2);
        public static Expr Sin(Expr arg) => new MSin(arg);
        public static Expr Cos(Expr arg) => new MCos(arg);
        public static Expr Tan(Expr arg) => new MTg(arg);
        public static Expr Ctan(Expr arg) => new MCtg(arg);
        public static Expr Sinh(Expr arg) => new MSin(arg);
        public static Expr Cosh(Expr arg) => new MCos(arg);
        public static Expr Tanh(Expr arg) => new MTg(arg);
        public static Expr Ctanh(Expr arg) => new MCtg(arg);
        public static Expr revSinh(Expr arg) => new Mrevsinh(arg);
        public static Expr revCosh(Expr arg) => new Mrevcosh(arg);
        public static Expr revTanh(Expr arg) => new Mrevtanh(arg);
        public static Expr revCtanh(Expr arg) => new Mrevcoth(arg);

    }

    class Vector : Expr
    {
        public override bool IsConstant => false;
        public override bool IsPolynom => true;
        public override Expr DiffExpr()
        {
            return 0;
        }

        private Expr[] exprs;
        private int Length;
        public static Vector operator +(Vector left, Vector right) => new Vector(left, right, true);
        public static Vector operator -(Vector left, Vector right) => new Vector(left, right, false);

        public static Expr operator *(Vector left, Vector right)
        {
            Expr result = new Constant(0);
            for (int i = 0; i < left.Length; i++)
                result += left.exprs[i] * right.exprs[i];
            return result;
        }

        public Vector(Expr[] names)
        {
            exprs = names;
            Length = names.Length;
        }

        public Vector(Vector left, Vector right, bool Addition)
        {
            exprs = new Expr[left.Length];
            if (Addition)
                for (int i = 0; i < left.Length; i++)
                    exprs[i] = left.exprs[i] + right.exprs[i];
            else
                for (int i = 0; i < left.Length; i++)
                    exprs[i] = left.exprs[i] - right.exprs[i];
            Length = left.Length;
        }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues)
        {
            return (this * this).Compute(variableValues);
        }

        public override IEnumerable<string> Variables { get; protected set; }
        public override string ToString()
        {
            string result = "";
            foreach (Expr expr in exprs)
                result = result + ", " + expr.ToString();
            return "(" + result.Substring(2) + ")";
        }
    }

    public abstract class UnaryOperation : Expr
    {
        public Expr _expr;
        public override bool IsConstant => false;
        public override bool IsPolynom => true;

        protected UnaryOperation(Expr e)
        {
            _expr = e;
        }

        protected double ComputeBase(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _expr.Compute(variableValues);
        }

       
    }
    abstract class BinaryOperation : Expr
    {
        protected Expr _expr1 { get; }
        protected Expr _expr2 { get; }

        public override bool IsConstant => false;
        public override bool IsPolynom => true;
        protected BinaryOperation(Expr exp1, Expr exp2)
        {
            _expr1 = exp1;
            _expr2 = exp2;
        }

    }

    public abstract class Function : Expr
    {
        public Expr _arg;
        public override bool IsConstant => false;
        public override bool IsPolynom => true;
        protected Function(Expr arg)
        {
            _arg = arg;
        }

        public override string ToString()
        {
            return _arg.Compute().ToString();
        }

        protected double ComputeBase(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _arg.Compute(variableValues);
        }
    }
    class Variable : Expr
    {
        public override bool IsConstant => false;
        public override bool IsPolynom => true;
        

        private readonly string _var;
        public override IEnumerable<string> Variables { get; protected set; }
        public Variable(string var)
        {
            _var = var;
        }

        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            if (variableValues == null) return 0;
            return variableValues.ContainsKey(_var) ? variableValues[_var] : 0;
        }
        public override string ToString() => _var;
        public override Expr DiffExpr()
        {

            return new  Constant(1);
        }

    }
    class Constant : Expr
    {
        private readonly double _value;
        private string constName = "";
        public override bool IsConstant => true;
        public override double Compute(IReadOnlyDictionary<string, double> variableValues = null)
        {
            return _value;
        }
        public Constant(string name) => constName = name;
        public Constant(double value)
        {
            _value = value;
        }
        override public bool IsPolynom => true;
        override public IEnumerable<string> Variables { get => null; protected set { } }
        public override Expr DiffExpr()
        {

            return new Constant(0);
        }
        public override string ToString()
        {
            if (constName.Length == 0) return _value.ToString();
            else return constName;
        }
    }


}