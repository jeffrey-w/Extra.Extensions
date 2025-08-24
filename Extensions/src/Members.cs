using System.Reflection;

namespace Extensions;

/// <summary>
/// The <c>MemberInfo</c> class provides additional operations on the <see cref="MemberInfo"/> type.
/// </summary>
public static class Members
{
    /// <summary>
    /// Determines whether this <see cref="MemberInfo"/> has the specified <see cref="Attribute"/>,
    /// <typeparamref name="TAttribute"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The <see cref="Type"/> of attribute that this <see cref="MemberInfo"/> is being
    /// queried for.</typeparam>
    /// <param name="member">This <see cref="MemberInfo"/>.</param>
    /// <returns><c>true</c> if this <see cref="MemberInfo"/> has the specified <see cref="Attribute"/>.</returns>
    public static bool HasCustomAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
    {
        return member.GetCustomAttributes<TAttribute>()
                     .Any();
    }
}
