namespace Extra.Extensions;

internal static class ConcatSelectionAccumulate
{
    public static ConcatSelectionAggregator<TElement> Empty<TElement>(Func<TElement, IEnumerable<TElement>> selector)
    {
        return new ConcatSelectionAggregator<TElement>([], [], selector);
    }
}

internal sealed class ConcatSelectionAggregator<TElement>
{
    private readonly IEnumerable<TElement> _prefix;
    private readonly IEnumerable<TElement> _suffix;
    private readonly Func<TElement, IEnumerable<TElement>> _selector;

    internal ConcatSelectionAggregator(
        IEnumerable<TElement> prefix,
        IEnumerable<TElement> suffix,
        Func<TElement, IEnumerable<TElement>> selector)
    {
        _prefix = prefix;
        _suffix = suffix;
        _selector = selector;
    }

    public ConcatSelectionAggregator<TElement> Add(TElement element)
    {
        return new ConcatSelectionAggregator<TElement>(
            _prefix.Append(element),
            _suffix.Concat(_selector(element)),
            _selector);
    }

    public IEnumerable<TElement> ToEnumerable()
    {
        return _prefix.Concat(_suffix);
    }
}
