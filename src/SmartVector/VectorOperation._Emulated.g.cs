using System;
using System.Collections.Generic;
using System.Text;

namespace SmartVector
{
    partial class VectorOperation
    {
        partial class _Emulated
        {
            protected internal override void AddCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Add(x, y[i]);
            }

            protected internal override void AddCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Add(x[i], y);
            }

            protected internal override void AddCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Add(x[i], y[i]);
            }

            protected internal override void SubtractCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Subtract(x, y[i]);
            }

            protected internal override void SubtractCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Subtract(x[i], y);
            }

            protected internal override void SubtractCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Subtract(x[i], y[i]);
            }

            protected internal override void MultiplyCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Multiply(x, y[i]);
            }

            protected internal override void MultiplyCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Multiply(x[i], y);
            }

            protected internal override void MultiplyCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Multiply(x[i], y[i]);
            }

            protected internal override void DivideCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Divide(x, y[i]);
            }

            protected internal override void DivideCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Divide(x[i], y);
            }

            protected internal override void DivideCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Divide(x[i], y[i]);
            }

            protected internal override void BitwiseAndCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseAnd(x, y[i]);
            }

            protected internal override void BitwiseAndCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseAnd(x[i], y);
            }

            protected internal override void BitwiseAndCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseAnd(x[i], y[i]);
            }

            protected internal override void BitwiseOrCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseOr(x, y[i]);
            }

            protected internal override void BitwiseOrCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseOr(x[i], y);
            }

            protected internal override void BitwiseOrCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseOr(x[i], y[i]);
            }

            protected internal override void BitwiseXorCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseXor(x, y[i]);
            }

            protected internal override void BitwiseXorCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseXor(x[i], y);
            }

            protected internal override void BitwiseXorCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.BitwiseXor(x[i], y[i]);
            }

/*
            protected internal override void EqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Equals(x, y[i]);
            }

            protected internal override void EqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Equals(x[i], y);
            }

            protected internal override void EqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.Equals(x[i], y[i]);
            }

            protected internal override void LessThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThan(x, y[i]);
            }

            protected internal override void LessThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThan(x[i], y);
            }

            protected internal override void LessThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThan(x[i], y[i]);
            }

            protected internal override void LessThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThanOrEquals(x, y[i]);
            }

            protected internal override void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThanOrEquals(x[i], y);
            }

            protected internal override void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.LessThanOrEquals(x[i], y[i]);
            }

            protected internal override void GreaterThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThan(x, y[i]);
            }

            protected internal override void GreaterThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThan(x[i], y);
            }

            protected internal override void GreaterThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThan(x[i], y[i]);
            }

            protected internal override void GreaterThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThanOrEquals(x, y[i]);
            }

            protected internal override void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThanOrEquals(x[i], y);
            }

            protected internal override void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            {
                for (var i = 0; i < ans.Length; ++i)
                    ans[i] = ValueOperation.GreaterThanOrEquals(x[i], y[i]);
            }

*/
        }
    }
}
