using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace SmartVector
{
    internal class DoubleComparer : IEqualityComparer<double>
    {
        public static DoubleComparer Instance { get; } = new();

        public static bool EqualsCore([AllowNull] double x, [AllowNull] double y)
                => (double.IsNaN(x), double.IsNaN(y)) switch
                {
                    (true, true) => true,
                    (true, false) => false,
                    (false, true) => false,
                    _ => x == y,
                };

        public bool Equals([AllowNull] double x, [AllowNull] double y) => EqualsCore(x, y);

        public int GetHashCode([DisallowNull] double obj) => 0;
    }


    internal class VectorComparer : IEqualityComparer<Vector<double>>
    {
        public static VectorComparer Instance { get; } = new();

        public bool Equals([AllowNull] Vector<double> x, [AllowNull] Vector<double> y)
        {
            for(var i = 0; i < Vector<double>.Count; ++i)
            {
                if (!DoubleComparer.EqualsCore(x[i], y[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode([DisallowNull] Vector<double> obj) => 0;
    }
}
