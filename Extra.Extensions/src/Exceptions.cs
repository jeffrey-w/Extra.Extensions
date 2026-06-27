namespace Extra.Extensions;

/// <summary>
/// The <c>Exceptions</c> class provides additional operations on the
/// <see cref="Exception" /> type.
/// </summary>
public static class Exceptions
{
    /// <summary>
    /// Executes the specified <paramref name="action"/>, ignoring any
    /// <see cref="Exception"/> that is thrown.
    /// </summary>
    /// <param name="action">
    /// A function from <see cref="Void"/> to <see cref="Void"/>.
    /// </param>
    public static void SuppressExceptions(Action action)
    {
        try
        {
            action();
        }
        catch
        {
            // ignored
        }
    }
    
    /// <summary>
    /// Executes the specified <paramref name="func"/>, ignoring any
    /// <see cref="Exception"/> that is thrown.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of value provided by the specified <paramref name="func"/>.
    /// </typeparam>
    /// <param name="func">
    /// A function from <see cref="Void"/> to <typeparamref name="TResult"/>.
    /// </param>
    public static TResult? SuppressExceptions<TResult>(Func<TResult> func)
    {
        try
        {
            return func();
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Executes the specified <paramref name="func"/>, ignoring any
    /// <see cref="Exception"/> that is thrown.
    /// </summary>
    /// <param name="func">
    /// A function from <see cref="Void"/> to <see cref="Task"/>.
    /// </param>
    /// <returns>
    /// The <see cref="Task"/> induced by the specified <paramref name="func"/>.
    /// </returns>
    public static Task SuppressExceptions(Func<Task> func)
    {
        try
        {
            return func();
        }
        catch
        {
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Executes the specified <paramref name="func"/>, ignoring any
    /// <see cref="Exception"/> that is thrown.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of value provided by the specified <paramref name="func"/>.
    /// </typeparam>
    /// <param name="func">
    /// A function from <see cref="Void"/> to <see cref="Task"/>s over
    /// <typeparamref name="TResult"/>.
    /// </param>
    public static Task<TResult?> SuppressExceptions<TResult>(Func<Task<TResult?>> func)
    {
        try
        {
            return func();
        }
        catch
        {
            return Task.FromResult(default(TResult));
        }
    }
}
