using System.Collections;

namespace Extensions;

internal sealed class CachedEnumerable<TElement>(IEnumerable<TElement> elements) : IEnumerable<TElement>
{
    private readonly List<TElement> cache = [];
    private readonly IEnumerator<TElement> enumerator = elements.GetEnumerator();

    public IEnumerator<TElement> GetEnumerator()
    {
        foreach (var element in cache)
        {
            yield return element;
        }
        while (enumerator.MoveNext())
        {
            cache.Add(enumerator.Current);
            yield return enumerator.Current;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
