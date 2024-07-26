namespace Extensions;

/// <summary>
/// The <c>Objects</c> class provides additional operations on the <see cref="object"/> type.
/// </summary>
public static class Objects
{
    /// <summary>
    /// Provides every <see cref="Type"/> associated with this <see cref="object"/>.
    /// </summary>
    /// <remarks>The provided collection of <see cref="Type"/>s excludes <c>typeof(object)</c>.</remarks>
    /// <param name="obj">This <see cref="object"/>.</param>
    /// <returns>The <see cref="Type"/>s to which this <see cref="object"/> belongs.</returns>
    public static IEnumerable<Type> GetEveryType(this object obj)
    {
        return obj.GetType()
                  .GetEveryBaseType();
    }
}
