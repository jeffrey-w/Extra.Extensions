namespace Extensions;

/// <summary>
/// The <c>IdentifyFunction</c> class provides a facility for obtaining mappings that associate elements from a set with
/// themselves.
/// </summary>
public static class IdentityFunction
{
    /// <summary>
    /// Provides the identity function over the specified type, <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The <see cref="Type"/> over which the provided identity function is
    /// defined.</typeparam>
    /// <returns>A function over <typeparamref name="TElement"/> that associates each element thereof with
    /// itself.</returns>
    public static Func<TElement, TElement> Make<TElement>()
    {
        return (TElement element) => element;
    }
}
