namespace Extensions;

/// <summary>
/// The <c>Types</c> class provides additional operations on the <see cref="Type"/> class.
/// </summary>
public static class Types
{
    /// <summary>
    /// Provides every <see cref="Type"/> from witch this one derives.
    /// </summary>
    /// <remarks>The provided collection of <see cref="Type"/>s excludes <c>typeof(object)</c>.</remarks>
    /// <param name="type">This <see cref="Type"/>.</param>
    /// <returns>The <see cref="Type"/>s that this one extends.</returns>
    public static IEnumerable<Type> GetEveryBaseType(this Type type)
    {
        var parent = type.BaseType;
        yield return type;
        while (parent is not null && parent != typeof(object))
        {
            yield return parent;
            parent = parent.BaseType;
        }
        foreach(var @interface in type.GetInterfaces())
        {
            yield return @interface;
        }
    }
}
