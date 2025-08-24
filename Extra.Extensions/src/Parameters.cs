using System.Reflection;

namespace Extra.Extensions;

/// <summary>
/// The <c>Parameters</c> class provides additional operations on the
/// <see cref="ParameterInfo" /> type.
/// </summary>
public static class Parameters
{
    /// <summary>
    /// Determines whether this <see cref="ParameterInfo" /> has the specified
    /// <see cref="Attribute" />, <typeparamref name="TAttribute" />.
    /// </summary>
    /// <typeparam name="TAttribute">
    /// The <see cref="Type" /> of attribute that this <see cref="ParameterInfo" /> is
    /// being queried for.
    /// </typeparam>
    /// <param name="parameter">This <see cref="ParameterInfo" />.</param>
    /// <returns>
    /// <c>true</c> if this <see cref="ParameterInfo" /> has the specified
    /// <see cref="Attribute" />.
    /// </returns>
    public static bool HasCustomAttribute<TAttribute>(this ParameterInfo parameter) where TAttribute : Attribute
    {
        return parameter
              .GetCustomAttributes<TAttribute>()
              .Any();
    }
}
