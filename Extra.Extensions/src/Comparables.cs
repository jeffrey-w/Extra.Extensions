namespace Extra.Extensions;

/// <summary>
/// The <c>Comparables</c> class provides additional operations on the
/// <see cref="IComparable{T}" /> type.
/// </summary>
public static class Comparables
{
    /// <summary>
    /// Additional operations on the specified <paramref name="comparable"/>.
    /// </summary>
    /// <typeparam name="T">The natural type of this
    /// <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="comparable">This <see cref="IComparable{T}"/>.</param>
    extension<T>(T comparable) where T : IComparable<T>
    {
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
