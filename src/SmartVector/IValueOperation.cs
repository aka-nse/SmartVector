namespace SmartVector;

/// <summary>
/// Provides operations.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValueOperation<T>
{
    /// <summary></summary>
    /// <param name="x"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T UnaryPlus(in T x);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T UnaryMinus(in T x);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Not(in T x);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Complement(in T x);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Add(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T AddChecked(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Subtract(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T SubtractChecked(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Multiply(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T MultiplyChecked(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Divide(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T Modulo(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T BitwiseOr(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T BitwiseAnd(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T BitwiseXor(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T ShiftRight(in T x, int y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    T ShiftLeft(in T x, int y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    bool Equals(in T x, in T y);

    /// <summary></summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException" />
    int Compare(in T x, in T y);
}
