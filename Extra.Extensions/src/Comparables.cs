namespace Extra.Extensions;

/// <summary>
/// The <c>Comparables</c> class provides additional operations on the
/// <see cref="IComparable{T}" /> type.
/// </summary>
public static class Comparables
{
    /// <summary>
    /// Determines whether this <see cref="IComparable{T}" /> precedes the
    /// <paramref name="other" />.
    /// </summary>
    /// <typeparam name="T">
    /// The compile-time <see cref="Type" /> of this <see cref="ICollection{T}" />.
    /// </typeparam>
    /// <param name="comparable">This <see cref="IComparable{T}" />.</param>
    /// <param name="other">
    /// The <see cref="IComparable{T}" /> against which this one is compared.
    /// </param>
    /// <returns>
    /// <c>true</c> if this <see cref="IComparable{T}" /> is less than the
    /// <paramref name="other" />.
    /// </returns>
    public static bool IsLessThan<T>(this T comparable, T other) where T : IComparable<T>
    {
        return comparable.CompareTo(other) < 0;
    }

    /// <summary>
    /// Determines whether this <see cref="IComparable{T}" /> precedes the
    /// <paramref name="other" />, or is equal to it.
    /// </summary>
    /// <typeparam name="T">
    /// The compile-time <see cref="Type" /> of this <see cref="ICollection{T}" />.
    /// </typeparam>
    /// <param name="comparable">This <see cref="IComparable{T}" />.</param>
    /// <param name="other">
    /// The <see cref="IComparable{T}" /> against which this one is compared.
    /// </param>
    /// <returns>
    /// <c>true</c> if this <see cref="IComparable{T}" /> is less than the
    /// <paramref name="other" />, or is equal to it.
    /// </returns>
    public static bool IsLessThanOrEqual<T>(this T comparable, T other) where T : IComparable<T>
    {
        return comparable.CompareTo(other) <= 0;
    }

    /// <summary>
    /// Determines whether this <see cref="IComparable{T}" /> succeeds the
    /// <paramref name="other" />.
    /// </summary>
    /// <typeparam name="T">
    /// The compile-time <see cref="Type" /> of this <see cref="ICollection{T}" />.
    /// </typeparam>
    /// <param name="comparable">This <see cref="IComparable{T}" />.</param>
    /// <param name="other">
    /// The <see cref="IComparable{T}" /> against which this one is compared.
    /// </param>
    /// <returns>
    /// <c>true</c> if this <see cref="IComparable{T}" /> is greater than the
    /// <paramref name="other" />.
    /// </returns>
    public static bool IsGreaterThan<T>(this T comparable, T other) where T : IComparable<T>
    {
        return comparable.CompareTo(other) > 0;
    }

    /// <summary>
    /// Determines whether this <see cref="IComparable{T}" /> succeeds the
    /// <paramref name="other" />, or is equal to it.
    /// </summary>
    /// <typeparam name="T">
    /// The compile-time <see cref="Type" /> of this <see cref="ICollection{T}" />.
    /// </typeparam>
    /// <param name="comparable">This <see cref="IComparable{T}" />.</param>
    /// <param name="other">
    /// The <see cref="IComparable{T}" /> against which this one is compared.
    /// </param>
    /// <returns>
    /// <c>true</c> if this <see cref="IComparable{T}" /> is greater than the
    /// <paramref name="other" />, or is equal to it.
    /// </returns>
    public static bool IsGreaterThanOrEqual<T>(this T comparable, T other) where T : IComparable<T>
    {
        return comparable.CompareTo(other) >= 0;
    }
}
