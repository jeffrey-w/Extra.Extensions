using System.Reflection;

namespace Extra.Extensions;

/// <summary>
/// The <c>Members</c> class provides additional operations on the
/// <see cref="MemberInfo" /> type.
/// </summary>
public static class Members
{
    /// <summary>
    /// Additional operations on the specified <paramref name="member"/>.
    /// </summary>
    /// <param name="member">This <see cref="MemberInfo"/>.</param>
    extension(MemberInfo member)
    {
        /// <summary>
        /// Determines whether this <see cref="MemberInfo" /> has the specified
        /// <see cref="Attribute" />, <typeparamref name="TAttribute" />.
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The <see cref="Type" /> of attribute that this <see cref="MemberInfo" /> is
        /// being queried for.
        /// </typeparam>
        /// <returns>
        /// <c>true</c> if this <see cref="MemberInfo" /> has the specified
        /// <see cref="Attribute" />.
        /// </returns>
        public bool HasCustomAttribute<TAttribute>() where TAttribute : Attribute
        {
            return member
                  .GetCustomAttributes<TAttribute>()
                  .Any();
        }
    }
}
