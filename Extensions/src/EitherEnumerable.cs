namespace Extensions;

/// <summary>
/// The <c>IEitherEnumerable</c> interface provides properties and operations on an <see cref="IEnumerable{T}"/> that is
/// in one of two states depending on the truth value of an arbitrary condition.
/// </summary>
/// <typeparam name="TElement">The type of element held by this <c>IEitherEnumerable</c>.</typeparam>
public interface IEitherEnumerable<TElement>
{
    /// <summary>
    /// Provides the <see cref="IEnumerable{T}"/> induced by the specified <paramref name="selector"/> if the condition
    /// supplied to this <c>IEitherEnumerable</c> is <c>true</c>, otherwise the <see cref="IEnumerable{T}"/> supplied,
    /// unmodified.
    /// </summary>
    /// <param name="selector">A function over <see cref="IEnumerable{T}"/>s.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/>.</returns>
    public IEnumerable<TElement> Then(Func<IEnumerable<TElement>, IEnumerable<TElement>> selector);
}

internal sealed class EitherEnumerable<TElement>(IEnumerable<TElement> elements, bool flag) : IEitherEnumerable<TElement>
{
    public IEnumerable<TElement> Then(Func<IEnumerable<TElement>, IEnumerable<TElement>> selector)
    {
        return flag ? selector(elements) : elements;
    }
}
