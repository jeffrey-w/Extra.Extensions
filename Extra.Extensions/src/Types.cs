namespace Extra.Extensions;

/// <summary>
/// The <c>Types</c> class provides additional operations on the
/// <see cref="Type" /> class.
/// </summary>
public static class Types
{
    /// <summary>
    /// Determines whether the <c>null</c> value belongs to this <see cref="Type" />.
    /// </summary>
    /// <param name="type">This <see cref="Type" />.</param>
    /// <returns>
    /// <c>true</c> if the <c>null</c> value belongs to this <see cref="Type" />.
    /// </returns>
    public static bool IsNullable(this Type type)
    {
        return !type.IsValueType || Nullable.GetUnderlyingType(type) is not null;
    }

    /// <summary>Determines whether this <see cref="Type" /> is static.</summary>
    /// <param name="type">This <see cref="Type" />.</param>
    /// <returns><c>true</c> if this <see cref="Type" /> is static.</returns>
    public static bool IsStatic(this Type type)
    {
        return type is { IsAbstract: true, IsSealed: true };
    }

    /// <summary>
    /// Provides every <see cref="Type" /> from witch this one derives.
    /// </summary>
    /// <remarks>
    /// The provided collection of <see cref="Type" />s excludes <c>typeof(object)</c>.
    /// </remarks>
    /// <param name="type">This <see cref="Type" />.</param>
    /// <returns>The <see cref="Type" />s that this one extends.</returns>
    public static IEnumerable<Type> GetEveryBaseType(this Type type)
    {
        var parent = type.BaseType;
        yield return type;
        while (parent is not null && parent != typeof(object))
        {
            yield return parent;
            parent = parent.BaseType;
        }
        foreach (var @interface in type.GetInterfaces())
        {
            yield return @interface;
        }
    }
}
