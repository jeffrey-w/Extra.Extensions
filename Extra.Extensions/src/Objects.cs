namespace Extra.Extensions;

/// <summary>
/// The <c>Objects</c> class provides additional operations on the
/// <see cref="object" /> type.
/// </summary>
public static class Objects
{
    /// <summary>
    /// Additional operations on the specified object, <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">This <see cref="object"/>.</param>
    extension(object obj)
    {
        /// <summary>
        /// Provides every <see cref="Type" /> associated with this <see cref="object" />.
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
                  .AllBaseTypes;
        }
    }

    /// <summary>
    /// Additional operations on the specified <paramref name="element"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of this <see cref="object"/>.</typeparam>
    /// <param name="element">This <see cref="object"/>.</param>
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
