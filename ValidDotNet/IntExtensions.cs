using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class IntExtensions
{
    /// <summary>
    ///     Handling the integer is negative check null or whitespace check and throw a ArgumentException
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="value">the value to check</param>
    /// <param name="message">a optional message instead of the default</param>
    public static int ThrowIfLessOrEqual(this int parameter,
        int value, [CallerArgumentExpression("parameter")] string parameterName = "", string? message = null)
    {
        if (parameter <= value)
            throw new ArgumentException(message ?? $"Parameter is less or equal to {value}!", parameterName);

        return parameter;
    }
}