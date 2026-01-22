namespace Extra.Extensions;

/// <summary>
/// The <c>Comparables</c> class provides additional operations on the
/// <see cref="IComparable{T}" /> type.
/// </summary>
public static class Comparables
{
    /// <param name="comparable">This <see cref="IComparable{T}" />.</param>
    /// <typeparam name="T">
    /// The compile-time <see cref="Type" /> of this <see cref="ICollection{T}" />.
    /// </typeparam>
    extension<T>(T comparable) where T : IComparable<T>
    {
        /// <summary>
        /// Determines whether the <paramref name="left"/> <see cref="IComparable{T}" />
        /// precedes the <paramref name="right" /> one.
        /// </summary>
        /// <param name="left">
        /// The <see cref="IComparable{T}"/> against which the <paramref name="right"/>
        /// one is compared.
        /// </param>
        /// <param name="right">
        /// The <see cref="IComparable{T}" /> against which the
        /// <paramref name="left"/> one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="left"/> <see cref="IComparable{T}" />
        /// is less than the <paramref name="right one" />.
        /// </returns>
        public static bool operator <(T left, T right)
        {
            return left.IsLessThan(right);
        }

        /// <summary>
        /// Determines whether the <paramref name="left"/> <see cref="IComparable{T}" />
        /// precedes the <paramref name="right" /> one, or is equal to it.
        /// </summary>
        /// <param name="left">
        /// The <see cref="IComparable{T}"/> against which the <paramref name="right"/>
        /// one is compared.
        /// </param>
        /// <param name="right">
        /// The <see cref="IComparable{T}" /> against which the
        /// <paramref name="left"/> one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="left"/> <see cref="IComparable{T}" />
        /// is less than or equal to the <paramref name="right one" />.
        /// </returns>
        public static bool operator <=(T left, T right)
        {
            return left.IsLessThanOrEqual(right);
        }

        /// <summary>
        /// Determines whether the <paramref name="left"/> <see cref="IComparable{T}" />
        /// succeeds the <paramref name="right" /> one.
        /// </summary>
        /// <param name="left">
        /// The <see cref="IComparable{T}"/> against which the <paramref name="right"/>
        /// one is compared.
        /// </param>
        /// <param name="right">
        /// The <see cref="IComparable{T}" /> against which the
        /// <paramref name="left"/> one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="left"/> <see cref="IComparable{T}" />
        /// is greater than the <paramref name="right one" />.
        /// </returns>
        public static bool operator >(T left, T right)
        {
            return left.IsGreaterThan(right);
        }

        /// <summary>
        /// Determines whether the <paramref name="left"/> <see cref="IComparable{T}" />
        /// succeeds the <paramref name="right" /> one, or is equal to it.
        /// </summary>
        /// <param name="left">
        /// The <see cref="IComparable{T}"/> against which the <paramref name="right"/>
        /// one is compared.
        /// </param>
        /// <param name="right">
        /// The <see cref="IComparable{T}" /> against which the
        /// <paramref name="left"/> one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="left"/> <see cref="IComparable{T}" />
        /// is greater than or equal to the <paramref name="right one" />.
        /// </returns>
        public static bool operator >=(T left, T right)
        {
            return left.IsGreaterThanOrEqual(right);
        }
        
        /// <summary>
        /// Determines whether this <see cref="IComparable{T}" /> precedes the
        /// <paramref name="other" />.
        /// </summary>
        /// <param name="other">
        /// The <see cref="IComparable{T}" /> against which this one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if this <see cref="IComparable{T}" /> is less than the
        /// <paramref name="other" />.
        /// </returns>
        public bool IsLessThan(T other)
        {
            return comparable.CompareTo(other) < 0;
        }

        /// <summary>
        /// Determines whether this <see cref="IComparable{T}" /> precedes the
        /// <paramref name="other" />, or is equal to it.
        /// </summary>
        /// <param name="other">
        /// The <see cref="IComparable{T}" /> against which this one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if this <see cref="IComparable{T}" /> is less than the
        /// <paramref name="other" />, or is equal to it.
        /// </returns>
        public bool IsLessThanOrEqual(T other)
        {
            return comparable.CompareTo(other) <= 0;
        }

        /// <summary>
        /// Determines whether this <see cref="IComparable{T}" /> succeeds the
        /// <paramref name="other" />.
        /// </summary>
        /// <param name="other">
        /// The <see cref="IComparable{T}" /> against which this one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if this <see cref="IComparable{T}" /> is greater than the
        /// <paramref name="other" />.
        /// </returns>
        public bool IsGreaterThan(T other)
        {
            return comparable.CompareTo(other) > 0;
        }

        /// <summary>
        /// Determines whether this <see cref="IComparable{T}" /> succeeds the
        /// <paramref name="other" />, or is equal to it.
        /// </summary>
        /// <param name="other">
        /// The <see cref="IComparable{T}" /> against which this one is compared.
        /// </param>
        /// <returns>
        /// <c>true</c> if this <see cref="IComparable{T}" /> is greater than the
        /// <paramref name="other" />, or is equal to it.
        /// </returns>
        public bool IsGreaterThanOrEqual(T other)
        {
            return comparable.CompareTo(other) >= 0;
        }
    }
}
