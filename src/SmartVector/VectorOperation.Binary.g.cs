#nullable enable
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SmartVector
{
    #region add
    partial class VectorOperation
    {
        /// <summary>
        /// Operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Add<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            AddCore(x, y, ans);
        }

        /// <summary>
        /// Operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Add<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            AddCore(x, y, ans);
        }

        /// <summary>
        /// Operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Add<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            AddCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void AddCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void AddCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void AddCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.AddCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void AddCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            Fallback.AddCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void AddCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            Fallback.AddCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void AddCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                AddCore(x_, y_, ans_);
                return;
            }
            Fallback.AddCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.AddCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.AddCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates add for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void AddCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.AddCore(x, y, ans);

    }
    #endregion

    #region subtract
    partial class VectorOperation
    {
        /// <summary>
        /// Operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Subtract<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            SubtractCore(x, y, ans);
        }

        /// <summary>
        /// Operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Subtract<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            SubtractCore(x, y, ans);
        }

        /// <summary>
        /// Operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Subtract<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            SubtractCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void SubtractCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void SubtractCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void SubtractCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.SubtractCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void SubtractCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            Fallback.SubtractCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void SubtractCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            Fallback.SubtractCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void SubtractCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                SubtractCore(x_, y_, ans_);
                return;
            }
            Fallback.SubtractCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.SubtractCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.SubtractCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates subtract for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void SubtractCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.SubtractCore(x, y, ans);

    }
    #endregion

    #region multiply
    partial class VectorOperation
    {
        /// <summary>
        /// Operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Multiply<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            MultiplyCore(x, y, ans);
        }

        /// <summary>
        /// Operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Multiply<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            MultiplyCore(x, y, ans);
        }

        /// <summary>
        /// Operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Multiply<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            MultiplyCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void MultiplyCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void MultiplyCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void MultiplyCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.MultiplyCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void MultiplyCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            Fallback.MultiplyCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void MultiplyCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            Fallback.MultiplyCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void MultiplyCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                MultiplyCore(x_, y_, ans_);
                return;
            }
            Fallback.MultiplyCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.MultiplyCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.MultiplyCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates multiply for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void MultiplyCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.MultiplyCore(x, y, ans);

    }
    #endregion

    #region divide
    partial class VectorOperation
    {
        /// <summary>
        /// Operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Divide<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            DivideCore(x, y, ans);
        }

        /// <summary>
        /// Operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Divide<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            DivideCore(x, y, ans);
        }

        /// <summary>
        /// Operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Divide<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            DivideCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void DivideCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void DivideCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void DivideCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.DivideCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void DivideCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            Fallback.DivideCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void DivideCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            Fallback.DivideCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void DivideCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                DivideCore(x_, y_, ans_);
                return;
            }
            Fallback.DivideCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.DivideCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.DivideCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates divide for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void DivideCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.DivideCore(x, y, ans);

    }
    #endregion

    #region bitwiseand
    partial class VectorOperation
    {
        /// <summary>
        /// Operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseAnd<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseAndCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseAnd<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            BitwiseAndCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseAnd<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseAndCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseAndCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseAndCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseAndCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseAndCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void BitwiseAndCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseAndCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseAndCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseAndCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseAndCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseAndCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseAndCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseAndCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseand for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseAndCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseAndCore(x, y, ans);

    }
    #endregion

    #region bitwiseor
    partial class VectorOperation
    {
        /// <summary>
        /// Operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseOr<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseOrCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseOr<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            BitwiseOrCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseOr<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseOrCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseOrCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseOrCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseOrCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseOrCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void BitwiseOrCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseOrCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseOrCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseOrCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseOrCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseOrCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseOrCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseOrCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwiseor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseOrCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseOrCore(x, y, ans);

    }
    #endregion

    #region bitwisexor
    partial class VectorOperation
    {
        /// <summary>
        /// Operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseXor<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseXorCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseXor<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            BitwiseXorCore(x, y, ans);
        }

        /// <summary>
        /// Operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void BitwiseXor<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            BitwiseXorCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseXorCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseXorCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void BitwiseXorCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.BitwiseXorCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void BitwiseXorCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseXorCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseXorCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseXorCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void BitwiseXorCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                BitwiseXorCore(x_, y_, ans_);
                return;
            }
            Fallback.BitwiseXorCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseXorCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates bitwisexor for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void BitwiseXorCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.BitwiseXorCore(x, y, ans);

    }
    #endregion

    #region equals
    partial class VectorOperation
    {
        /// <summary>
        /// Operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Equals<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            EqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Equals<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            EqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void Equals<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            EqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void EqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void EqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void EqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.EqualsCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void EqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.EqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void EqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.EqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void EqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                EqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.EqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.EqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.EqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates equals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void EqualsCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.EqualsCore(x, y, ans);

    }
    #endregion

    #region lessthan
    partial class VectorOperation
    {
        /// <summary>
        /// Operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThan<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            LessThanCore(x, y, ans);
        }

        /// <summary>
        /// Operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThan<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            LessThanCore(x, y, ans);
        }

        /// <summary>
        /// Operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThan<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            LessThanCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void LessThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void LessThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void LessThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.LessThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.LessThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.LessThanCore(x, y, ans);

    }
    #endregion

    #region lessthanorequals
    partial class VectorOperation
    {
        /// <summary>
        /// Operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThanOrEquals<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            LessThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThanOrEquals<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            LessThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void LessThanOrEquals<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            LessThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.LessThanOrEqualsCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void LessThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanOrEqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanOrEqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void LessThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                LessThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.LessThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates lessthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void LessThanOrEqualsCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.LessThanOrEqualsCore(x, y, ans);

    }
    #endregion

    #region greaterthan
    partial class VectorOperation
    {
        /// <summary>
        /// Operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThan<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            GreaterThanCore(x, y, ans);
        }

        /// <summary>
        /// Operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThan<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            GreaterThanCore(x, y, ans);
        }

        /// <summary>
        /// Operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThan<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            GreaterThanCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void GreaterThanCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void GreaterThanCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void GreaterThanCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.GreaterThanCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.GreaterThanCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthan for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.GreaterThanCore(x, y, ans);

    }
    #endregion

    #region greaterthanorequals
    partial class VectorOperation
    {
        /// <summary>
        /// Operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="y"/> and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThanOrEquals<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThanOrEquals<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// Operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="ArgumentException"> <paramref name="x"/>, <paramref name="y"/>, and <paramref name="ans"/> must have same length. </exception>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        public void GreaterThanOrEquals<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
        {
            if(x.Length != ans.Length)
                throw new ArgumentException("`x` and `ans` must have same length.");
            if(y.Length != ans.Length)
                throw new ArgumentException("`y` and `ans` must have same length.");
            GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/> and <paramref name="y"/>.
        /// Implementation can assume that <paramref name="x"/> and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <typeparam name="T"> The type of elements. </typeparam>
        /// <param name="x"> The operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation for <typeparamref name="T"/> is not supported. </exception>
        protected internal virtual void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
            where T : unmanaged
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
    }

    partial class VectorOperationSpecialized
    {
        /// <inheritdoc />
        protected internal override sealed void GreaterThanOrEqualsCore<T>(T x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = Unsafe.As<T, sbyte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = Unsafe.As<T, short>(ref x); 
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = Unsafe.As<T, int>(ref x); 
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = Unsafe.As<T, long>(ref x); 
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = Unsafe.As<T, byte>(ref x); 
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = Unsafe.As<T, ushort>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = Unsafe.As<T, uint>(ref x); 
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = Unsafe.As<T, ulong>(ref x); 
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = Unsafe.As<T, float>(ref x); 
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = Unsafe.As<T, double>(ref x); 
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, T y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = Unsafe.As<T, sbyte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = Unsafe.As<T, short>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = Unsafe.As<T, int>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = Unsafe.As<T, long>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = Unsafe.As<T, byte>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = Unsafe.As<T, ushort>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = Unsafe.As<T, uint>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = Unsafe.As<T, ulong>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = Unsafe.As<T, float>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = Unsafe.As<T, double>(ref y); 
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <inheritdoc />
        protected internal override sealed void GreaterThanOrEqualsCore<T>(ReadOnlySpan<T> x, ReadOnlySpan<T> y, Span<T> ans)
        {
            if(typeof(T) == typeof(sbyte))
            {
                var x_ = MemoryMarshal.Cast<T, sbyte>(x);
                var y_ = MemoryMarshal.Cast<T, sbyte>(y);
                var ans_ = MemoryMarshal.Cast<T, sbyte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(short))
            {
                var x_ = MemoryMarshal.Cast<T, short>(x);
                var y_ = MemoryMarshal.Cast<T, short>(y);
                var ans_ = MemoryMarshal.Cast<T, short>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(int))
            {
                var x_ = MemoryMarshal.Cast<T, int>(x);
                var y_ = MemoryMarshal.Cast<T, int>(y);
                var ans_ = MemoryMarshal.Cast<T, int>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(long))
            {
                var x_ = MemoryMarshal.Cast<T, long>(x);
                var y_ = MemoryMarshal.Cast<T, long>(y);
                var ans_ = MemoryMarshal.Cast<T, long>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(byte))
            {
                var x_ = MemoryMarshal.Cast<T, byte>(x);
                var y_ = MemoryMarshal.Cast<T, byte>(y);
                var ans_ = MemoryMarshal.Cast<T, byte>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ushort))
            {
                var x_ = MemoryMarshal.Cast<T, ushort>(x);
                var y_ = MemoryMarshal.Cast<T, ushort>(y);
                var ans_ = MemoryMarshal.Cast<T, ushort>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(uint))
            {
                var x_ = MemoryMarshal.Cast<T, uint>(x);
                var y_ = MemoryMarshal.Cast<T, uint>(y);
                var ans_ = MemoryMarshal.Cast<T, uint>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(ulong))
            {
                var x_ = MemoryMarshal.Cast<T, ulong>(x);
                var y_ = MemoryMarshal.Cast<T, ulong>(y);
                var ans_ = MemoryMarshal.Cast<T, ulong>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(float))
            {
                var x_ = MemoryMarshal.Cast<T, float>(x);
                var y_ = MemoryMarshal.Cast<T, float>(y);
                var ans_ = MemoryMarshal.Cast<T, float>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            if(typeof(T) == typeof(double))
            {
                var x_ = MemoryMarshal.Cast<T, double>(x);
                var y_ = MemoryMarshal.Cast<T, double>(y);
                var ans_ = MemoryMarshal.Cast<T, double>(ans);
                GreaterThanOrEqualsCore(x_, y_, ans_);
                return;
            }
            Fallback.GreaterThanOrEqualsCore(x, y, ans);
        }

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(sbyte x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<sbyte> x, sbyte y, Span<sbyte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<sbyte> x, ReadOnlySpan<sbyte> y, Span<sbyte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(short x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<short> x, short y, Span<short> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<short> x, ReadOnlySpan<short> y, Span<short> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(int x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<int> x, int y, Span<int> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<int> x, ReadOnlySpan<int> y, Span<int> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(long x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<long> x, long y, Span<long> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<long> x, ReadOnlySpan<long> y, Span<long> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(byte x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<byte> x, byte y, Span<byte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ushort x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<ushort> x, ushort y, Span<ushort> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<ushort> x, ReadOnlySpan<ushort> y, Span<ushort> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(uint x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<uint> x, uint y, Span<uint> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<uint> x, ReadOnlySpan<uint> y, Span<uint> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ulong x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<ulong> x, ulong y, Span<ulong> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<ulong> x, ReadOnlySpan<ulong> y, Span<ulong> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(float x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<float> x, float y, Span<float> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<float> x, ReadOnlySpan<float> y, Span<float> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(double x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);
            
        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<double> x, double y, Span<double> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

        /// <summary>
        /// When overridden in a derived class, operates greaterthanorequals for each corresponding elements of <paramref name="x"/>.
        /// Implementation can assume that <paramref name="x"/>, <paramref name="y"/>  and <paramref name="ans"/> have strictly same length.
        /// </summary>
        /// <param name="x"> The left hand side operand elements. </param>
        /// <param name="y"> The right hand side operand elements. </param>
        /// <param name="ans"> The destination of answer. </param>
        /// <exception cref="NotSupportedException"> The operation is not supported. </exception>
        protected virtual void GreaterThanOrEqualsCore(ReadOnlySpan<double> x, ReadOnlySpan<double> y, Span<double> ans)
            => Fallback.GreaterThanOrEqualsCore(x, y, ans);

    }
    #endregion

}
