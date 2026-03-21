namespace Extra.Extensions;

/// <summary>
/// The <c>Strings</c> class provides additional operations on the
/// <see cref="string" /> type.
/// </summary>
public static class Strings
{
    /// <summary>
    /// Provides the string produced by surrounding this one with quotation
    /// marks.
    /// </summary>
    /// <param name="s">This <see cref="string"/>.</param>
    /// <returns>A new <see cref="string"/>.</returns>
    public static string Quote(this string s)
    {
        return $"\"{s}\"";
    }
}
