namespace Extensions;

/// <summary>
/// The <c>Objects</c> class provides additional operations on the
/// <see cref="object" /> type.
/// </summary>
public static class Objects
{
    /// <summary>
    /// Provides every <see cref="Type" /> associated with this <see cref="object" />.
    /// </summary>
    /// <remarks>
    /// The provided collection of <see cref="Type" />s excludes <c>typeof(object)</c>.
    /// </remarks>
    /// <param name="obj">This <see cref="object" />.</param>
    /// <returns>
    /// The <see cref="Type" />s to which this <see cref="object" /> belongs.
    /// </returns>
    public static IEnumerable<Type> GetEveryType(this object obj)
    {
        return obj
              .GetType()
              .GetEveryBaseType();
    }

    /// <summary>
    /// Provides the <see cref="HashSet{T}" /> containing only this
    /// <see cref="object" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The <see cref="Type" /> to which this <see cref="object" /> belongs.
    /// </typeparam>
    /// <param name="element">This <see cref="object" />.</param>
    /// <returns>
    /// This <see cref="object" />, wrapped in a <see cref="HashSet{T}" />.
    /// </returns>
    public static ISet<TElement> ToSingletonHashSet<TElement>(TElement element)
    {
        return new HashSet<TElement> { element };
    }
}
