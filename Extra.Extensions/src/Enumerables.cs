namespace Extra.Extensions;

/// <summary>
/// The <c>Enumerables</c> class provides additional operations on the
/// <see cref="IEnumerable{T}" /> type.
/// </summary>
public static class Enumerables
{
    /// <summary>
    /// Determines whether the <paramref name="first"/> and
    /// <paramref name="second"/> <see cref="IEnumerable{T}"/>s are equal by
    /// virtue of containing the same elements in the same order, or because
    /// both are <c>null</c>.
    /// </summary>
    /// <typeparam name="TElement">The type of element that the specified
    /// <see cref="IEnumerable{T}"/>s hold.</typeparam>
    /// <param name="first">One the <see cref="IEnumerable{T}"/>s to compare.</param>
    /// <param name="second">The other <see cref="IEnumerable{T}"/> to compare.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> by which
    /// comparisons are made.</param>
    /// <returns><c>true</c> if both <see cref="IEnumerable{T}"/>s contain the
    /// same elements in the same order, or are both <c>null</c>.</returns>
    public static bool NullableSequenceEqual<TElement>(
        IEnumerable<TElement>? first,
        IEnumerable<TElement>? second,
        IEqualityComparer<TElement>? comparer = null)
    {
        return first is null ? second is null : second is not null && first.SequenceEqual(second, comparer);
    }
    
    /// <summary>
    /// Provides the element from <typeparamref name="TResult" /> obtained by combining
    /// the elements from this <see cref="IEnumerable{T}" /> into an element from
    /// <typeparamref name="TAccumulate" />, initialized by the specified
    /// <paramref name="seed" />, and then applying the specified
    /// <paramref name="selector" /> to the result.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <typeparam name="TAccumulate">
    /// The type into which elements from this <see cref="IEnumerable{T}" /> are
    /// combined.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type that the specified <paramref name="selector" /> projects members of
    /// <typeparamref name="TAccumulate" /> to.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="seed">
    /// The value from which combination of elements in this
    /// <see cref="IEnumerable{T}" /> initiates.
    /// </param>
    /// <param name="accumulator">
    /// An asynchronous function from <typeparamref name="TAccumulate" />-
    /// <typeparamref name="TElement" /> pairs to <typeparamref name="TAccumulate" />.
    /// </param>
    /// <param name="selector">
    /// A function from <typeparamref name="TAccumulate" /> to
    /// <typeparamref name="TResult" />.
    /// </param>
    /// <returns>A new <typeparamref name="TResult" /> instance.</returns>
    public static async Task<TResult> AggregateAsync<TElement, TAccumulate, TResult>(
        this IEnumerable<TElement> elements,
        TAccumulate seed,
        Func<TAccumulate, TElement, Task<TAccumulate>> accumulator,
        Func<TAccumulate, TResult> selector)
    {
        foreach (var element in elements)
        {
            seed = await accumulator(seed, element);
        }
        return selector(seed);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by including the specified
    /// <paramref name="element" /> at the end of this one, if it satisfies the
    /// specified <paramref name="predicate" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="element">
    /// The item to include in the new <see cref="IEnumerable{T}" />.
    /// </param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TElement" /> to <see cref="bool" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> AppendIf<TElement>(
        this IEnumerable<TElement> elements,
        TElement element,
        Func<TElement, bool> predicate)
    {
        return predicate(element) ? elements.Append(element) : elements;
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by including the specified
    /// <paramref name="element" /> at the end of this one, if it is not <c>null</c>.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="element">
    /// The item to include in the new <see cref="IEnumerable{T}" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> AppendIfNotNull<TElement>(
        this IEnumerable<TElement> elements,
        TElement? element)
    {
        return elements.AppendIf(element!, element => element is not null);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by including the specified
    /// <paramref name="element" /> at the beginning of this one, if it satisfies the
    /// specified <paramref name="predicate" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="element">
    /// The item to include in the new <see cref="IEnumerable{T}" />.
    /// </param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TElement" /> to <see cref="bool" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> PrependIf<TElement>(
        this IEnumerable<TElement> elements,
        TElement element,
        Func<TElement, bool> predicate)
    {
        return predicate(element) ? elements.Prepend(element) : elements;
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by including the specified
    /// <paramref name="element" /> at the beginning of this one, if it is not
    /// <c>null</c>.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="element">
    /// The item to include in the new <see cref="IEnumerable{T}" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> PrependIfNotNull<TElement>(
        this IEnumerable<TElement> elements,
        TElement? element)
    {
        return elements.PrependIf(element!, element => element is not null);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> that contains the same elements as
    /// this one, but that only evaluates them once upon first emission from an
    /// associated <see cref="IEnumerator{T}" />.
    /// </summary>
    /// <remarks>
    /// Note that this method is not semantically equivalent to those that force
    /// immediate evaluation (e.g.,
    /// <see cref="Enumerable.ToList{TSource}(IEnumerable{TSource})">ToList</see>)
    /// since the elements contained by the new <see cref="IEnumerable{T}" /> are still
    /// lazily evaluated during an initial enumeration, but are not reevaluated during
    /// subsequent ones. Caution using this method is advised since it may alter the
    /// expected semantics of enumeration. Specifically, the effect of adding or
    /// removing elements from the data structure that backs this
    /// <see cref="IEnumerable{T}" /> will not be observed by enumerating the returned
    /// <see cref="IEnumerable{T}" />. Additionally, no guarantees are made with
    /// respect to the thread safety of the cached <see cref="IEnumerable{T}" />, and
    /// concurrent iterations should be externally synchronized.
    /// </remarks>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> Cached<TElement>(this IEnumerable<TElement> elements)
    {
        return new CachedEnumerable<TElement>(elements);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> that contains every element from
    /// this one, and those induced by applying the specified
    /// <paramref name="selector" /> to them.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">A relation over <typeparamref name="TElement" />.</param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> ConcatSelection<TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, IEnumerable<TElement>> selector)
    {
        return elements.Aggregate(
            ConcatSelectionAccumulate.Empty(selector),
            (accumulate, element) => accumulate.Add(element),
            accumulate => accumulate.ToEnumerable());
    }

    /// <summary>
    /// Performs the specified <paramref name="action" /> on each element from this
    /// <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="action">
    /// The logic to execute against each element from this
    /// <see cref="IEnumerable{T}" />.
    /// </param>
    public static void ForEach<TElement>(this IEnumerable<TElement> elements, Action<TElement> action)
    {
        foreach (var element in elements)
        {
            action(element);
        }
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> that contains the elements from
    /// this one, each associated with the ordinal at which it is emitted
    /// incremented by the specified <paramref name="origin" />.
    /// </summary>
    /// <typeparam name="TElement">The type of element held by this
    /// <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}"/>.</param>
    /// <param name="origin">The offset by which the ordinal for each element is
    /// incremented.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/>.</returns>
    public static IEnumerable<(int index, TElement element)> IndexFrom<TElement>(
        this IEnumerable<TElement> elements,
        int origin)
    {
        return elements.Select((element, index) => (index + origin, element));
    }

    /// <summary>
    /// Determines whether this <see cref="IEnumerable{T}" /> contains only one
    /// element.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>
    /// <c>true</c> if this <see cref="IEnumerable{T}" /> is a singleton.
    /// </returns>
    public static bool IsSingleton<TElement>(this IEnumerable<TElement> elements)
    {
        var count = 0;
        foreach (var _ in elements)
        {
            if (++count > 1)
            {
                return false;
            }
        }
        return count == 1;
    }

    /// <summary>
    /// Determines whether any element from this <see cref="IEnumerable{T}" /> does not
    /// satisfy the specified <paramref name="predicate" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TElement" /> to <see cref="bool" />.
    /// </param>
    /// <returns>
    /// <c>true</c> if at least one element from this <see cref="IEnumerable{T}" />
    /// does not satisfy the specified <paramref name="predicate" />.
    /// </returns>
    public static bool NotAll<TElement>(this IEnumerable<TElement> elements, Func<TElement, bool> predicate)
    {
        return elements.Any(element => !predicate(element));
    }

    /// <summary>
    /// Determines whether this <see cref="IEnumerable{T}" /> is empty.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>
    /// <c>true</c> if this <see cref="IEnumerable{T}" /> contains no elements.
    /// </returns>
    public static bool NotAny<TElement>(this IEnumerable<TElement> elements)
    {
        return !elements.Any();
    }

    /// <summary>
    /// Determines whether no element from this <see cref="IEnumerable{T}" /> satisfies
    /// the specified <paramref name="predicate" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TElement" /> to <see cref="bool" />.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified <paramref name="predicate" /> is not satisfied by
    /// any element from this <see cref="IEnumerable{T}" />.
    /// </returns>
    public static bool NotAny<TElement>(this IEnumerable<TElement> elements, Func<TElement, bool> predicate)
    {
        return !elements.Any(predicate);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by applying the specified
    /// <paramref name="selector" /> to each element in this one.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type that the specified <paramref name="selector" /> projects elements from
    /// this <see cref="IEnumerable{T}" /> to.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">
    /// A function from <typeparamref name="TElement" /> to
    /// <typeparamref name="TResult" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static async Task<IEnumerable<TResult>> SelectAsync<TElement, TResult>(
        this IEnumerable<TElement> elements,
        Func<TElement, Task<TResult>> selector)
    {
        return await elements.AggregateAsync(
            Enumerable.Empty<TResult>(),
            async (results, element) => results.Append(await selector(element)),
            results => results);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by applying the specified
    /// <paramref name="selector" /> to the elements from this one, retaining only
    /// those projections that are not <c>null</c>.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type that the specified <paramref name="selector" /> projects elements from
    /// this <see cref="IEnumerable{T}" /> to.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">
    /// A function from <typeparamref name="TElement" /> to
    /// <typeparamref name="TResult" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TResult> SelectNotNull<TElement, TResult>(
        this IEnumerable<TElement> elements,
        Func<TElement, TResult?> selector)
    {
        return elements
              .Select(selector)
              .WhereNotNull()
              .Cast<TResult>();
    }

    /// <summary>
    /// Provides the hash code for this <see cref="IEnumerable{T}" />, computed over
    /// the elements it contains.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> by which
    /// to compute hash codes.</param>
    /// <returns>The has code for this <see cref="IEnumerable{T}" />.</returns>
    public static int SequenceHashCode<TElement>(
        this IEnumerable<TElement> elements,
        IEqualityComparer<TElement>? comparer = null)
    {
        return elements.Aggregate(
            new HashCode(),
            (code, element) => Combine(code, element, comparer),
            code => code.ToHashCode());
    }

    private static HashCode Combine<TElement>(
        HashCode code,
        TElement element,
        IEqualityComparer<TElement>? comparer)
    {
        code.Add(element, comparer);
        return code;
    }

    /// <summary>
    /// Provides the elements from this <see cref="IEnumerable{T}" /> in a random
    /// order.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> Shuffle<TElement>(this IEnumerable<TElement> elements)
    {
        return elements.Shuffle(new Random());
    }

    /// <summary>
    /// Provides the elements from this <see cref="IEnumerable{T}" /> in a random order
    /// induced by the specified <paramref name="random" /> number generator.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="random">A source of randomness.</param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> Shuffle<TElement>(this IEnumerable<TElement> elements, Random random)
    {
        return elements
              .Select(element => new { Ordinal = random.Next(), Element = element })
              .OrderBy(obj => obj.Ordinal)
              .Select(obj => obj.Element);
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by selecting the elements
    /// emitted by this one that satisfy the specified <paramref name="predicate" />
    /// when combined by the specified <paramref name="accumulator" />. The combination
    /// against which the specified <paramref name="predicate" /> is evaluated is
    /// initialized by the specified <paramref name="seed" />.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <typeparam name="TAccumulate">
    /// The type into which elements from this <see cref="IEnumerable{T}" /> are
    /// combined, and against which the specified <paramref name="predicate" /> is
    /// evaluated.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="seed">
    /// The initial value from <typeparamref name="TAccumulate" /> with which elements
    /// from this <see cref="IEnumerable{T}" /> are combined.
    /// </param>
    /// <param name="accumulator">
    /// A function from <typeparamref name="TAccumulate" />-
    /// <typeparamref name="TElement" /> pairs to <typeparamref name="TAccumulate" />.
    /// </param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TAccumulate" />-
    /// <typeparamref name="TElement" /> pairs to <see cref="bool" />.
    /// </param>
    /// <returns>
    /// A new <see cref="IEnumerable{T}" /> that contains the elements emitted by the
    /// enumerator for this one until their combination, induced by the specified
    /// <paramref name="accumulator" />, no longer satisfies the specified
    /// <paramref name="predicate" />.
    /// </returns>
    public static IEnumerable<TElement> TakeWhileAggregate<TElement, TAccumulate>(
        this IEnumerable<TElement> elements,
        TAccumulate seed,
        Func<TAccumulate, TElement, TAccumulate> accumulator,
        Func<TAccumulate, TElement, bool> predicate)
    {
        foreach (var element in elements)
        {
            if (predicate(seed, element))
            {
                seed = accumulator(seed, element);
                yield return element;
            }
            else
            {
                yield break;
            }
        }
    }

    /// <summary>
    /// Verifies that no pair of elements from this <see cref="IEnumerable{T}" /> are
    /// equal.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>
    /// A new <see cref="IEnumerable{T}" /> containing the elements from this one if no
    /// pair of them are equal.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// If any pair of elements from this <see cref="IEnumerable{T}" /> are equal.
    /// </exception>
    public static IEnumerable<TElement> ThrowIfDuplicates<TElement>(this IEnumerable<TElement> elements)
    {
        return elements.ThrowIfDuplicatesBy(element => element);
    }

    /// <summary>
    /// Verifies that the specified <paramref name="selector" /> maps every element
    /// from this <see cref="IEnumerable{T}" /> to a unique value from
    /// <typeparamref name="TKey" />.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type over which elements from this <see cref="IEnumerable{T}" /> are
    /// compared for uniqueness.
    /// </typeparam>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">
    /// A function from <typeparamref name="TElement" /> to
    /// <typeparamref name="TKey" />.
    /// </param>
    /// <returns>
    /// A new <see cref="IEnumerable{T}" /> containing the elements from this one if
    /// the specified <paramref name="selector" /> maps every element in it to a unique
    /// value from <typeparamref name="TKey" />.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// If the specified <paramref name="selector" /> does not map every element from
    /// this <see cref="IEnumerable{T}" /> to a unique value in
    /// <typeparamref name="TKey" />.
    /// </exception>
    public static IEnumerable<TElement> ThrowIfDuplicatesBy<TKey, TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, TKey> selector)
    {
        var keys = new HashSet<TKey>();
        foreach (var element in elements)
        {
            if (keys.Add(selector(element)))
            {
                yield return element;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    /// <summary>
    /// Provides the <see cref="IDictionary{TKey,TValue}" /> induced by applying the
    /// specified <paramref name="selector" /> to the elements from this
    /// <see cref="IEnumerable{T}" />, and associating each result with its preimage.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type over which elements from this <see cref="IEnumerable{T}" /> are
    /// distinguished.
    /// </typeparam>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">
    /// A relation from <typeparamref name="TElement" /> to
    /// <typeparamref name="TKey" />.
    /// </param>
    /// <returns>A new <see cref="IDictionary{TKey,TValue}" />.</returns>
    /// <exception cref="ArgumentException">
    /// If the inverse of the specified <paramref name="selector" /> applied to the
    /// elements from <typeparamref name="TKey" /> does not define a function to
    /// <typeparamref name="TElement" />.
    /// </exception>
    public static IDictionary<TKey, TElement> ToDictionaryInverse<TKey, TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, IEnumerable<TKey>> selector) where TKey : notnull
    {
        return elements
              .SelectMany(element => MakePairs(element, selector(element)))
              .ToDictionary(pair => pair.key, pair => pair.element);
    }

    /// <summary>
    /// Provides the <see cref="IDictionary{TKey,TValue}" /> induced by applying the
    /// specified <paramref name="keySelector" /> to the elements from this
    /// <see cref="IEnumerable{T}" />, and associating each result with the value
    /// obtained by applying the specified <paramref name="valueSelector" /> to its
    /// preimage.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type over which elements from this <see cref="IEnumerable{T}" /> are
    /// distinguished.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type to which each element from this <see cref="IEnumerable{T}" /> is
    /// mapped.
    /// </typeparam>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="keySelector">
    /// A relation from <typeparamref name="TElement" /> to
    /// <typeparamref name="TKey" />.
    /// </param>
    /// <param name="valueSelector">
    /// A function from <typeparamref name="TElement" /> to
    /// <typeparamref name="TValue" />.
    /// </param>
    /// <returns>A new <see cref="IDictionary{TKey,TValue}" />.</returns>
    /// <exception cref="ArgumentException">
    /// If the inverse of the specified <paramref name="keySelector" /> applied to the
    /// elements from <typeparamref name="TKey" /> does not define a function to
    /// <typeparamref name="TValue" />.
    /// </exception>
    public static IDictionary<TKey, TValue> ToDictionaryInverse<TKey, TValue, TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, IEnumerable<TKey>> keySelector,
        Func<TElement, TValue> valueSelector) where TKey : notnull
    {
        return elements
              .SelectMany(element => MakePairs(valueSelector.Invoke(element), keySelector(element)))
              .ToDictionary(pair => pair.key, pair => pair.element);
    }

    /// <summary>
    /// Provides the <see cref="ILookup{TKey,TValue}" /> induced by applying the
    /// specified <paramref name="selector" /> to the elements from this
    /// <see cref="IEnumerable{T}" />, and associating each result with its preimages.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type over which elements from this <see cref="IEnumerable{T}" /> are
    /// distinguished.
    /// </typeparam>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="selector">
    /// A relation from <typeparamref name="TElement" /> to
    /// <typeparamref name="TKey" />.
    /// </param>
    /// <returns>A new <see cref="ILookup{TKey,TValue}" />.</returns>
    public static ILookup<TKey, TElement> ToLookupInverse<TKey, TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, IEnumerable<TKey>> selector)
    {
        return elements
              .SelectMany(element => MakePairs(element, selector(element)))
              .ToLookup(pair => pair.key, pair => pair.element);
    }

    /// <summary>
    /// Provides the <see cref="ILookup{TKey,TValue}" /> induced by applying the
    /// specified <paramref name="keySelector" /> to the elements from this
    /// <see cref="IEnumerable{T}" />, and associating each result with the value
    /// obtained by applying the specified <paramref name="valueSelector" /> to its
    /// preimages.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type over which elements from this <see cref="IEnumerable{T}" /> are
    /// distinguished.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type to which each element from this <see cref="IEnumerable{T}" /> is
    /// mapped.
    /// </typeparam>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="keySelector">
    /// A relation from <typeparamref name="TElement" /> to
    /// <typeparamref name="TKey" />.
    /// </param>
    /// <param name="valueSelector">
    /// A function from <typeparamref name="TElement" /> to
    /// <typeparamref name="TValue" />.
    /// </param>
    /// <returns>A new <see cref="ILookup{TKey,TValue}" />.</returns>
    public static ILookup<TKey, TValue> ToLookupInverse<TKey, TValue, TElement>(
        this IEnumerable<TElement> elements,
        Func<TElement, IEnumerable<TKey>> keySelector,
        Func<TElement, TValue> valueSelector)
    {
        return elements
              .SelectMany(element => MakePairs(valueSelector(element), keySelector(element)))
              .ToLookup(pair => pair.key, pair => pair.element);
    }

    private static IEnumerable<(TKey key, TElement element)> MakePairs<TKey, TElement>(
        TElement element,
        IEnumerable<TKey> keys)
    {
        return keys.Select(key => (key, element));
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by selecting those elements
    /// from this one that do not satisfy the specified <paramref name="predicate" />.
    /// </summary>
    /// <typeparam name="TElements">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <param name="predicate">
    /// A function from <typeparamref name="TElements" /> to <see cref="bool" />.
    /// </param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElements> WhereNot<TElements>(
        this IEnumerable<TElements> elements,
        Func<TElements, bool> predicate)
    {
        return elements.Where(element => !predicate(element));
    }

    /// <summary>
    /// Provides the <see cref="IEnumerable{T}" /> induced by selecting those elements
    /// from this one that are not <c>null</c>.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of element held by this <see cref="IEnumerable{T}" />.
    /// </typeparam>
    /// <param name="elements">This <see cref="IEnumerable{T}" />.</param>
    /// <returns>A new <see cref="IEnumerable{T}" />.</returns>
    public static IEnumerable<TElement> WhereNotNull<TElement>(this IEnumerable<TElement> elements)
    {
        return elements.Where(element => element is not null);
    }
}
