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
        public static IEnumerable<object[]> TestCase_Visit()
        {
            static object[] core(Vector<double> x, Vector<double> y, Expression< Func<double, double, double>> methodExpression)
                => new object[] { x, y, methodExpression, };

            var arguments = new Vector<double>[]
            {
                new(),
                new(1.0),
                new(-1.0),
                new(double.MinValue),
                new(double.MaxValue),
                new(double.PositiveInfinity),
                new(double.NegativeInfinity),
                new(stackalloc double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, }),
                new(stackalloc double[] { -1.0, -2.0, -3.0, -4.0, -5.0, -6.0, -7.0, -8.0, }),
            };

            foreach(var x in arguments)
            {
                foreach(var y in arguments)
                {
                    yield return core(x, y, (x, y) => 0);
                    yield return core(x, y, (x, y) => x);
                    yield return core(x, y, (x, y) => y);
                    yield return core(x, y, (x, y) => x + y);
                    yield return core(x, y, (x, y) => x - y);
                    yield return core(x, y, (x, y) => x * y);
                    yield return core(x, y, (x, y) => x / y);
                    yield return core(x, y, (x, y) => Math.Max(x, y));
                    yield return core(x, y, (x, y) => Math.Min(x, y));
                    yield return core(x, y, (x, y) => Math.Pow(x, y));
                    yield return core(x, y, (x, y) => Math.Log(x, y));
                }
            }
            yield break;
        }


        [Theory]
        [MemberData(nameof(TestCase_Visit))]
        public void Visit(Vector<double> x, Vector<double> y, Expression<Func<double, double, double>> methodExpression)
        {
            var method = methodExpression.Compile();
            var visitor = new VectorizationVisitor(Enumerable.Empty<IMethodReplacementStrategy>());
            var visitedMethodExpr = visitor.Visit(methodExpression);
            var visitedMethod = (Func<Vector<double>, Vector<double>, Vector<double>>)((LambdaExpression)visitedMethodExpr).Compile();
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
            Assert.Equal(expected, actual, VectorComparer.Instance);
        }
    }
}
