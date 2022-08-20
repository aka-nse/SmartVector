using System;
using System.Collections.Generic;
using System.Text;

namespace SmartVector
{
    partial class VectorOperation
    {
#pragma warning disable IDE1006
        partial class _Emulated
        {
            /*
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
            */
        }
    }
}
