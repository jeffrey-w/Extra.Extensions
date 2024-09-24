using System.Collections;

namespace Extensions;

internal sealed class CachedEnumerable<TElement>(IEnumerable<TElement> elements) : IEnumerable<TElement>
{
    private readonly List<TElement> _cache = [];
    private readonly IEnumerator<TElement> _enumerator = elements.GetEnumerator();

    public IEnumerator<TElement> GetEnumerator()
    {
        foreach (var element in _cache)
        {
            yield return element;
        }
        while (_enumerator.MoveNext())
        {
            _cache.Add(_enumerator.Current);
            yield return _enumerator.Current;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
