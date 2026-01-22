namespace Extra.Extensions;

/// <summary>
/// The <c>Objects</c> class provides additional operations on the
/// <see cref="object" /> type.
/// </summary>
public static class Objects
{
    /// <param name="obj">This <see cref="object" />.</param>
    extension(object obj)
    {
        /// <summary>
        /// Provides every <see cref="Type" /> to which this <see cref="object" />
        /// belongs.
        /// </summary>
        /// <remarks>
        /// The provided collection of <see cref="Type" />s excludes <c>typeof(object)</c>.
        /// </remarks>
        /// <returns>
        /// The <see cref="Type" />s to which this <see cref="object" /> belongs.
        /// </returns>
        public IEnumerable<Type> GetEveryType()
        {
            return obj
                  .GetType()
                  .EveryBaseType;
        }
    }

    /// <param name="element">This <see cref="object" />.</param>
    /// <typeparam name="TElement">
    /// The <see cref="Type" /> to which this <see cref="object" /> belongs.
    /// </typeparam>
    extension<TElement>(TElement element)
    {
        /// <summary>
        /// Provides the <see cref="HashSet{T}" /> containing only this
        /// <see cref="object" />.
        /// </summary>
        /// <returns>
        /// This <see cref="object" />, wrapped in a <see cref="HashSet{T}" />.
        /// </returns>
        public ISet<TElement> ToSingletonHashSet()
        {
            return new HashSet<TElement> { element };
        }
    }
}
