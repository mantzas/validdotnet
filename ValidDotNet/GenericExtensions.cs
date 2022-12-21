using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class GenericExtensions
{
    /// <summary>
    ///     Handling the null check and throw a ArgumentNullException if null
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static T ThrowIfNull<T>(this T parameter, [CallerArgumentExpression("parameter")] string parameterName = "",
        string? message = null) where T : class?
    {
        if (parameter == null) throw new ArgumentNullException(parameterName, message ?? "Parameter is null!");

        return parameter;
    }
}