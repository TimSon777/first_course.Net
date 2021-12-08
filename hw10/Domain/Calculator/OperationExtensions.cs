using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw10.Services.Calculator
{
    public static class OperationExtensions
    {
        public static bool TryParse(string str, out Operation operation)
        {
            operation = str switch
            {
                "+" => Operation.Plus,
                "-" => Operation.Minus,
                "*" => Operation.Multiplication,
                "/" => Operation.Division,
                "(" => Operation.LeftBracket,
                ")" => Operation.RightBracket,
                _   => Operation.Plus
            };

            return operation != Operation.Plus || str == "+";
        }
        
        public static BinaryExpression ToBinaryExpression(this Operation operation, 
            Expression left, 
            Expression right)
        {
            return operation switch
            {
                Operation.Plus             => Expression.Add(left, right),
                Operation.Minus            => Expression.Subtract(left, right),
                Operation.Division         => Expression.Divide(left, right),
                Operation.Multiplication   => Expression.Multiply(left, right),
                Operation.LeftBracket      => throw new ArgumentException(),
                Operation.RightBracket     => throw new ArgumentException(),
                _                          => throw new NotImplementedException()
            };
        }
        
        public static BinaryExpression ToBinaryExpression(this Operation operation, Stack<Expression> output)
        {
            if (output.Count < 2) throw new ArgumentException();
            var right = output.Pop();
            var left = output.Pop();
            return operation.ToBinaryExpression(left, right);
        }
        
                
        public static readonly Dictionary<Operation, byte> Priorities = new()
        {
            { Operation.LeftBracket,       0 },
            { Operation.RightBracket,      0 },
            { Operation.Plus,              1 },
            { Operation.Minus,             1 },
            { Operation.Division,          2 },
            { Operation.Multiplication,    2 }
        };
    }
}