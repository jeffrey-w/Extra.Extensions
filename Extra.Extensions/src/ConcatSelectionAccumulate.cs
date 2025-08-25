namespace Extra.Extensions;

internal static class ConcatSelectionAccumulate
{
    public static ConcatSelectionAccumulate<TElement> Empty<TElement>(Func<TElement, IEnumerable<TElement>> selector)
    {
        return new ConcatSelectionAccumulate<TElement>([], [], selector);
    }
}

internal sealed class ConcatSelectionAccumulate<TElement>
{
    private readonly IEnumerable<TElement> _prefix;
    private readonly IEnumerable<TElement> _suffix;
    private readonly Func<TElement, IEnumerable<TElement>> _selector;

    internal ConcatSelectionAccumulate(
        IEnumerable<TElement> prefix,
        IEnumerable<TElement> suffix,
        Func<TElement, IEnumerable<TElement>> selector)
    {
        _prefix = prefix;
        _suffix = suffix;
        _selector = selector;
    }

    public ConcatSelectionAccumulate<TElement> Add(TElement element)
    {
        return new ConcatSelectionAccumulate<TElement>(
            _prefix.Append(element),
            _suffix.Concat(_selector(element)),
            _selector);
    }

    public IEnumerable<TElement> ToEnumerable()
    {
        return _prefix.Concat(_suffix);
    }
}
