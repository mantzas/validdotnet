using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class ArrayExtensions
{
    /// <summary>
    ///     Handling the null and empty check of an array and throw a
    ///     ArgumentNullException if null and ArgumentException if empty
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <param name="parameter">the actual parameter array</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static T[] ThrowIfNullOrEmpty<T>(this T[] parameter,
        [CallerArgumentExpression("parameter")]
        string parameterName = "", string? message = null) where T : class
    {
        if (parameter == null) throw new ArgumentNullException(parameterName, message ?? "Parameter is null!");

        if (parameter.Length == 0) throw new ArgumentException("Parameter is empty!", parameterName);

        return parameter;
    }
}