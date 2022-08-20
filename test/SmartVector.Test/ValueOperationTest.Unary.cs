using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SmartVector
{
    partial class ValueOperationTest<T, TArgProvider>
        where TArgProvider : struct, ValueOperationTest<T, TArgProvider>.IArgProvider
    {
        protected static object[] UnaryTestCase(bool supported, T input, T expected)
            => new object[] { supported, input!, expected! };


        partial interface IArgProvider { IEnumerable<object[]> TestArgs_UnaryPlus(); }
        public static IEnumerable<object[]> TestArgs_UnaryPlus() => ArgProvider.TestArgs_UnaryPlus();
        [Theory]
        [MemberData(nameof(TestArgs_UnaryPlus))]
        public void UnaryPlus(bool supported, T input, T expected)
        {
            if(supported)
            {
                Assert.Equal(expected, ValueOperation.UnaryPlus(input), Comparer);
            }
            else
            {
                Assert.Throws<NotSupportedException>(() => ValueOperation.UnaryPlus(input));
            }
        }


        partial interface IArgProvider { IEnumerable<object[]> TestArgs_UnaryMinus(); }
        public static IEnumerable<object[]> TestArgs_UnaryMinus() => ArgProvider.TestArgs_UnaryMinus();
        [Theory]
        [MemberData(nameof(TestArgs_UnaryMinus))]
        public void UnaryMinus(bool supported, T input, T expected)
        {
            if(supported)
            {
                Assert.Equal(expected, ValueOperation.UnaryMinus(input), Comparer);
            }
            else
            {
                Assert.Throws<NotSupportedException>(() => ValueOperation.UnaryMinus(input));
            }
        }
    }


    partial class ValueOperationTest_uint
    {
        partial struct ArgProvider
        {
            public IEnumerable<object[]> TestArgs_UnaryPlus()
            {
                yield return UnaryTestCase(false, 0, 0);
            }

            public IEnumerable<object[]> TestArgs_UnaryMinus()
            {
                yield return UnaryTestCase(false, 0, 0);
            }
        }
    }


    partial class ValueOperationTest_int
    {
        partial struct ArgProvider
        {
            public IEnumerable<object[]> TestArgs_UnaryPlus()
            {
                yield return UnaryTestCase(true, 0, 0);
                yield return UnaryTestCase(true, 1, 1);
                yield return UnaryTestCase(true, -1, -1);
            }

            public IEnumerable<object[]> TestArgs_UnaryMinus()
            {
                yield return UnaryTestCase(true, 0, 0);
                yield return UnaryTestCase(true, 1, -1);
                yield return UnaryTestCase(true, -1, 1);
            }
        }
    }
}
