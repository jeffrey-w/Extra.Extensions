namespace Extra.Extensions;

/// <summary>
/// The <c>Integers</c> class provides additional operations on the
/// <see cref="int" /> type.
/// </summary>
public static class Integers
{
    /// <summary>
    /// Determines whether this <see cref="int" /> is one less than the
    /// <paramref name="other" /> one.
    /// </summary>
    /// <param name="i"> This <see cref="int" />.</param>
    /// <param name="other">The <see cref="int" /> to compare against this one.</param>
    /// <returns>
    /// <c>true</c> if this <see cref="int" /> is one less than the
    /// <paramref name="other" /> one.
    /// </returns>
    public static bool IsPredecessor(this int i, int other)
    {
        return other - 1 == i;
    }

    /// <summary>
    /// Determines whether this <see cref="int" /> is one greater than the
    /// <paramref name="other" /> one.
    /// </summary>
    /// <param name="i"> This <see cref="int" />.</param>
    /// <param name="other">The <see cref="int" /> to compare against this one.</param>
    /// <returns>
    /// <c>true</c> if this <see cref="int" /> is one greater than the
    /// <paramref name="other" /> one.
    /// </returns>
    public static bool IsSuccessor(this int i, int other)
    {
        return other + 1 == i;
    }

    /// <summary>
    /// Determines whether this <see cref="int"/> is a multiple of the
    /// <paramref name="other"/> one.
    /// </summary>
    /// <param name="i">This <see cref="int"/>.</param>
    /// <param name="other">The <see cref="int"/> to compare against this one</param>
    /// <returns><c>true</c> if this <see cref="int"/> is a multiple of the
    /// <paramref name="other"/> one.</returns>
    [Obsolete(
        "This method will be removed in a future release. The overload accepting a nullable integer ought to be preferred.")]
    public static bool IsDividedBy(this int i, int other)
    {
        return IsDividedBy(i, (int?)other);
    }

    /// <summary>
    /// Determines whether this <see cref="int"/> is a multiple of the
    /// <paramref name="other"/> one.
    /// </summary>
    /// <param name="i">This <see cref="int"/>.</param>
    /// <param name="other">The <see cref="int"/> to compare against this one</param>
    /// <returns><c>true</c> if this <see cref="int"/> is a multiple of the
    /// <paramref name="other"/> one.</returns>
    public static bool IsDividedBy(this int i, int? other)
    {
        return i % other == 0;
    }
}
