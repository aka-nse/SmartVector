// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY T4. DO NOT CHANGE IT. CHANGE THE .tt FILE INSTEAD.
// </auto-generated>
using System.Runtime.CompilerServices;
namespace SmartVector;

partial class ValueOperation
{
    /// <summary> Compares 2 values of <typeparamref name="T"/>. </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals<T>(in T x, in T y)
    {
        if(typeof(T) == typeof(bool))
        {
            var xx = Unsafe.As<T, bool>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, bool>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(byte))
        {
            var xx = Unsafe.As<T, byte>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, byte>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(ushort))
        {
            var xx = Unsafe.As<T, ushort>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, ushort>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(uint))
        {
            var xx = Unsafe.As<T, uint>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, uint>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(ulong))
        {
            var xx = Unsafe.As<T, ulong>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, ulong>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(sbyte))
        {
            var xx = Unsafe.As<T, sbyte>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, sbyte>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(short))
        {
            var xx = Unsafe.As<T, short>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, short>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(int))
        {
            var xx = Unsafe.As<T, int>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, int>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(long))
        {
            var xx = Unsafe.As<T, long>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, long>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(float))
        {
            var xx = Unsafe.As<T, float>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, float>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(double))
        {
            var xx = Unsafe.As<T, double>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, double>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        if(typeof(T) == typeof(decimal))
        {
            var xx = Unsafe.As<T, decimal>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, decimal>(ref Unsafe.AsRef(y));
            return xx == yy;
        }
        return Cache<T>.Instance.Equals(x, y);
    }


    /// <summary> Compares 2 values of <typeparamref name="T"/>. </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare<T>(in T x, in T y)
    {
        if(typeof(T) == typeof(bool))
        {
            throw new NotSupportedException();
        }
        if(typeof(T) == typeof(byte))
        {
            var xx = Unsafe.As<T, byte>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, byte>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(ushort))
        {
            var xx = Unsafe.As<T, ushort>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, ushort>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(uint))
        {
            var xx = Unsafe.As<T, uint>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, uint>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(ulong))
        {
            var xx = Unsafe.As<T, ulong>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, ulong>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(sbyte))
        {
            var xx = Unsafe.As<T, sbyte>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, sbyte>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(short))
        {
            var xx = Unsafe.As<T, short>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, short>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(int))
        {
            var xx = Unsafe.As<T, int>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, int>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(long))
        {
            var xx = Unsafe.As<T, long>(ref Unsafe.AsRef(x));
            var yy = Unsafe.As<T, long>(ref Unsafe.AsRef(y));
            if(xx == yy)
                return 0;
            return xx > yy ? 1: -1;
        }
        if(typeof(T) == typeof(float))
        {
            throw new NotSupportedException();
        }
        if(typeof(T) == typeof(double))
        {
            throw new NotSupportedException();
        }
        if(typeof(T) == typeof(decimal))
        {
            throw new NotSupportedException();
        }
        return Cache<T>.Instance.Compare(x, y);
    }
}
