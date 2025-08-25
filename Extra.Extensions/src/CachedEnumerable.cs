using System.Collections;

namespace Extra.Extensions;

internal sealed class CachedEnumerable<TElement>(IEnumerable<TElement> elements) : IEnumerable<TElement>
{
    private readonly IEnumerator<TElement> _enumerator = elements.GetEnumerator();
    private readonly List<TElement> _cache = [];

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
