#nullable enable
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SmartVector
{
    #region unaryplus
    partial class VectorOperation
    {
        /// <summary>
        /// Operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException">
        /// <paramref name="x"/> and <paramref name="ans"/> must have same length.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// The operation for <typeparamref name="T"/> is not supported.
        /// </exception>
        public void UnaryPlus<T>(ReadOnlySpan<T> x, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            UnaryPlusCore(x, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation for <typeparamref name="T"/> is not supported.
        /// </exception>
        protected internal virtual void UnaryPlusCore<T>(ReadOnlySpan<T> x, Span<T> ans)
            where T : unmanaged
            => Fallback.UnaryPlusCore(x, ans);
    }


    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void UnaryPlusCore<T>(ReadOnlySpan<T> x, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                UnaryPlusCore(x_, ans_);
                return;
            }
            Fallback.UnaryPlusCore(x, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<sbyte> x, Span<sbyte> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<short> x, Span<short> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<int> x, Span<int> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<long> x, Span<long> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<byte> x, Span<byte> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<ushort> x, Span<ushort> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<uint> x, Span<uint> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<ulong> x, Span<ulong> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<float> x, Span<float> ans)
            => Fallback.UnaryPlusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryplus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryPlusCore(ReadOnlySpan<double> x, Span<double> ans)
            => Fallback.UnaryPlusCore(x, ans);

    }
    #endregion


    #region unaryminus
    partial class VectorOperation
    {
        /// <summary>
        /// Operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException">
        /// <paramref name="x"/> and <paramref name="ans"/> must have same length.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// The operation for <typeparamref name="T"/> is not supported.
        /// </exception>
        public void UnaryMinus<T>(ReadOnlySpan<T> x, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            UnaryMinusCore(x, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation for <typeparamref name="T"/> is not supported.
        /// </exception>
        protected internal virtual void UnaryMinusCore<T>(ReadOnlySpan<T> x, Span<T> ans)
            where T : unmanaged
            => Fallback.UnaryMinusCore(x, ans);
    }


    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void UnaryMinusCore<T>(ReadOnlySpan<T> x, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                UnaryMinusCore(x_, ans_);
                return;
            }
            Fallback.UnaryMinusCore(x, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<sbyte> x, Span<sbyte> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<short> x, Span<short> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<int> x, Span<int> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<long> x, Span<long> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<byte> x, Span<byte> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<ushort> x, Span<ushort> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<uint> x, Span<uint> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<ulong> x, Span<ulong> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<float> x, Span<float> ans)
            => Fallback.UnaryMinusCore(x, ans);

        /// <summary>
        /// When overridden in a derived class, operates unaryminus for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException">
        /// The operation is not supported.
        /// </exception>
        protected virtual void UnaryMinusCore(ReadOnlySpan<double> x, Span<double> ans)
            => Fallback.UnaryMinusCore(x, ans);

    }
    #endregion


}
