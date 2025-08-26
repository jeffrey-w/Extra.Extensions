namespace Extra.Extensions;

/// <summary>
/// The <c>Types</c> class provides additional operations on the
/// <see cref="Type" /> class.
/// </summary>
public static class Types
{
    /// <summary>
    /// Additional operations on the specified <paramref name="type"/>.
    /// </summary>
    /// <param name="type">This <see cref="Type"/>.</param>
    extension(Type type)
    {
        /// <summary>
        /// Indicates whether the <c>null</c> value belongs to this <see cref="Type" />.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the <c>null</c> value belongs to this <see cref="Type" />.
        /// </returns>
        public bool IsNullable => !type.IsValueType || Nullable.GetUnderlyingType(type) is not null;

        /// <summary>Indicates whether this <see cref="Type" /> is static.</summary>
        /// <returns><c>true</c> if this <see cref="Type" /> is static.</returns>
        public bool IsStatic => type is { IsAbstract: true, IsSealed: true };

        /// <summary>Every <see cref="Type" /> from witch this one derives.</summary>
        /// <remarks>
        /// The provided collection of <see cref="Type" />s excludes <c>typeof(object)</c>.
        /// </remarks>
        /// <returns>The <see cref="Type" />s that this one extends.</returns>
        public IEnumerable<Type> AllBaseTypes
        {
            get
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
    }
}
