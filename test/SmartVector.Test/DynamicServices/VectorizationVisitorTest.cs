using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using Xunit;

namespace SmartVector.DynamicServices
{
    public class VectorizationVisitorTest
    {
        [Fact]
        public void Visit()
        {
            Expression<Func<double, double, double>> methodExpr = (x, y) => Math.Pow(x, y);
            var method = methodExpr.Compile();
            var visitor = new VectorizationVisitor(Enumerable.Empty<IMethodReplacementStrategy>());
            var visitedMethodExpr = visitor.Visit(methodExpr);
            var visitedMethod = (Func<Vector<double>, Vector<double>, Vector<double>>)((LambdaExpression)visitedMethodExpr).Compile();

            var x = new Vector<double>(stackalloc double[] { 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, });
            var y = new Vector<double>(stackalloc double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, });
            Vector<double> expected;
            {
                Span<double> _expected = stackalloc double[Vector<double>.Count];
                for(var i = 0; i < Vector<double>.Count; ++i)
                {
                    _expected[i] = method(x[i], y[i]);
                }
                expected = new Vector<double>(_expected);
            }
            var actual = visitedMethod(x, y);
            Assert.Equal(expected, actual);
        }
    }
}
