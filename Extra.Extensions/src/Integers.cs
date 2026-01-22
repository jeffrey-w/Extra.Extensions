namespace Extra.Extensions;

/// <summary>
/// The <c>Integers</c> class provides additional operations on the
/// <see cref="int" /> type.
/// </summary>
public static class Integers
{
    /// <param name="i"> This <see cref="int" />.</param>
    extension(int i)
    {
        /// <summary>
        /// Determines whether this <see cref="int" /> is one less than the
        /// <paramref name="other" /> one.
        /// </summary>
        /// <param name="other">The <see cref="int" /> to compare against this one.</param>
        /// <returns>
        /// <c>true</c> if this <see cref="int" /> is one less than the
        /// <paramref name="other" /> one.
        /// </returns>
        public bool IsPredecessor(int other)
        {
            return other - 1 == i;
        }

        /// <summary>
        /// Determines whether this <see cref="int" /> is one greater than the
        /// <paramref name="other" /> one.
        /// </summary>
        /// <param name="other">The <see cref="int" /> to compare against this one.</param>
        /// <returns>
        /// <c>true</c> if this <see cref="int" /> is one greater than the
        /// <paramref name="other" /> one.
        /// </returns>
        public bool IsSuccessor(int other)
        {
            return other + 1 == i;
        }

        /// <summary>
        /// Determines whether this <see cref="int"/> is a multiple of the
        /// <paramref name="other"/> one.
        /// </summary>
        /// <param name="other">The <see cref="int"/> to compare against this one</param>
        /// <returns><c>true</c> if this <see cref="int"/> is a multiple of the
        /// <see cref="other"/> one.</returns>
        public bool IsDividedBy(int other)
        {
            return i % other == 0;
        }
    }
}
