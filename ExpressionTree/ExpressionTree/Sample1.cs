using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace ExpressionTree
{
    public static class Sample1
    {
        public static void Test()
        {
            // Add the following using directive to your code file:  
            // using System.Linq.Expressions;  

            // Manually build the expression tree for   
            // the lambda expression num => num < 5.  
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda1 =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanFive,
                    new ParameterExpression[] { numParam });

            var ret = lambda1.Compile()(1);

            Console.WriteLine($"this is a new world:  {ret.ToString()}");
        }
    }
}
