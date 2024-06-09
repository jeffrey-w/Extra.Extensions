using System.Reflection;

using Member = System.Reflection.MemberInfo;

namespace Extensions;

/// <summary>
/// The <c>MemberInfo</c> class provides additional operations on the <see cref="Member"/> type.
/// </summary>
public static class MemberInfo
{
    /// <summary>
    /// Determines whether this <see cref="Member"/> has the specified <see cref="Attribute"/>,
    /// <typeparamref name="TAttribute"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The <see cref="Type"/> of attribute that this <see cref="Member"/> is being
    /// queried for.</typeparam>
    /// <param name="member">This <see cref="Member"/>.</param>
    /// <returns><c>true</c> if this <see cref="Member"/> has the specified <see
    /// cref="Attribute"/>.</returns>
    public static bool HasCustomAttribute<TAttribute>(this Member member) where TAttribute : Attribute
    {
        return member.GetCustomAttribute<TAttribute>() is not null;
    }

    /// <summary>
    /// Determines whether this <see cref="Type"/> is static.
    /// </summary>
    /// <param name="type">This <see cref="Type"/>.</param>
    /// <returns><c>true</c> if this <see cref="Type"/> is static.</returns>
    public static bool IsStatic(this Type type)
    {
        return type.IsAbstract && type.IsSealed;
    }
}
