﻿using System;

namespace eXpressionParsing
{
    abstract class Operand
    {
        // Skip node number and just do it in one iteration, print the label
        // for operands and print label + connections for operators.
        public int NodeNumber { get; set; }
        public object Data { get; }
        public Operand(object data)
        {
            Data = data;
        }
        public abstract double Calculate(double x);
        public abstract Operand Differentiate();
        public abstract Operand Copy();
        public virtual Operand Simplify() // Wil simplify where possible and else return a copy of itself.
        {
            return Copy();
        }
        public override string ToString()
        {
            return Convert.ToString(Data);
        }

        public virtual string NodeLabel()
        {
            return $"\tnode{NodeNumber} [ label = \"{Data}\" ]\n";
        }
    }
}
