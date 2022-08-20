using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace SmartVector
{
    public abstract partial class ValueOperationTest<T, TArgProvider>
        where TArgProvider : struct, ValueOperationTest<T, TArgProvider>.IArgProvider
    {
        public partial interface IArgProvider
        {
            IEqualityComparer<T> Comparer { get; }
        }
        private static TArgProvider ArgProvider { get; } = default;
        private static IEqualityComparer<T> Comparer => ArgProvider.Comparer;
    }


    public partial class ValueOperationTest_uint
        : ValueOperationTest<uint, ValueOperationTest_uint.ArgProvider>
    {
        public partial struct ArgProvider : IArgProvider
        {
            public IEqualityComparer<uint> Comparer => EqualityComparer<uint>.Default;
        }
    }


    public partial class ValueOperationTest_int
        : ValueOperationTest<int, ValueOperationTest_int.ArgProvider>
    {
        public partial struct ArgProvider : IArgProvider
        {
            public IEqualityComparer<int> Comparer => EqualityComparer<int>.Default;
        }
    }
}
