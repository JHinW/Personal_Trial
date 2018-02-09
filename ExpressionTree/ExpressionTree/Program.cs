using ExpressionTree.exp;
using System;
using System.Threading;

namespace ExpressionTree
{
    // https://stackoverflow.com/questions/32284043/what-is-the-difference-between-expression-variable-and-expression-parameter

    internal static  class Program
    {
        static void Main(string[] args)
        {
            Sample2.Test();
            LamdaExpression.Test();
            ExpCall.Test();

            Console.WriteLine("Hello World!");
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
