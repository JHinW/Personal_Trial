using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionTree
{
    public static class LamdaExpression
    {
        public static void Test()
        {
            // Creating an expression tree.  
            Expression<Func<int, bool>> expr = num => num < 5;

            // Compiling the expression tree into a delegate.  
            Func<int, bool> result = expr.Compile();

            // Invoking the delegate and writing the result to the console.  
            Console.WriteLine(result(4));

            // Prints True.  

            // You can also use simplified syntax  
            // to compile and run an expression tree.  
            // The following line can replace two previous statements.  
            Console.WriteLine(expr.Compile()(4));

            // Also prints True.s
        }
    }
}
