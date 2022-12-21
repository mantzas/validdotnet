using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class StringExtensions
{
    /// <summary>
    ///     Handling the null or whitespace check and throw a ArgumentException
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static string ThrowIfNullOrWhitespace(this string parameter,
        [CallerArgumentExpression("parameter")]
        string parameterName = "", string? message = null)
    {
        if (string.IsNullOrWhiteSpace(parameter))
            throw new ArgumentException(message ?? "Parameter is null or whitespace!", parameterName);

        return parameter;
    }
}