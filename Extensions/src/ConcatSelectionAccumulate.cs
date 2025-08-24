namespace Extensions;

internal static class ConcatSelectionAccumulate
{
    public static ConcatSelectionAggregator<TElement> Empty<TElement>()
    {
        return new ConcatSelectionAggregator<TElement>([], []);
    }
}

internal sealed class ConcatSelectionAggregator<TElement>
{
    private readonly IEnumerable<TElement> _prefix;
    private readonly IEnumerable<TElement> _suffix;

    internal ConcatSelectionAggregator(IEnumerable<TElement> prefix, IEnumerable<TElement> suffix)
    {
        _prefix = prefix;
        _suffix = suffix;
    }

    public ConcatSelectionAggregator<TElement> Add(TElement element, Func<TElement, IEnumerable<TElement>> selector)
    {
        return new ConcatSelectionAggregator<TElement>(_prefix.Append(element), _suffix.Concat(selector(element)));
    }

    public IEnumerable<TElement> ToEnumerable()
    {
        return _prefix.Concat(_suffix);
    }
}
