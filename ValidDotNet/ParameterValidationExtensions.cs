namespace ValidDotNet;

public static class ParameterValidationExtensions
{
    #region Generic of class

    /// <summary>
    /// Handling the null check and throw a ArgumentNullException if null
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static T ThrowIfNull<T>(this T parameter, string parameterName, string? message = null) where T : class?
    {
        if (parameter == null)
        {
            throw new ArgumentNullException(parameterName, message ?? "Parameter is null!");
        }

        return parameter;
    }

    /// <summary>
    /// Handling the null and empty check of an array and throw a 
    /// ArgumentNullException if null and ArgumentException if empty
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <param name="parameter">the actual parameter array</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static T[] ThrowIfNullOrEmpty<T>(this T[] parameter, string parameterName, string? message = null) where T : class
    {
        if (parameter == null)
        {
            throw new ArgumentNullException(parameterName, message ?? "Parameter is null!");
        }

        if (parameter.Length == 0)
        {
            throw new ArgumentException("Parameter is empty!", parameterName);
        }

        return parameter;
    }

    #endregion

    #region TimeSpan

    /// <summary>
    /// Handling the zero check and throw a ArgumentException if TimeSpan.Zero
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static TimeSpan ThrowIfZero(this TimeSpan parameter, string parameterName, string? message = null)
    {
        if (parameter == TimeSpan.Zero)
        {
            throw new ArgumentException(message ?? "Parameter is zero!", parameterName);
        }

        return parameter;
    }

    #endregion

    #region String

    /// <summary>
    /// Handling the null or whitespace check and throw a ArgumentException
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static string ThrowIfNullOrWhitespace(this string parameter, string parameterName, string? message = null)
    {
        if (string.IsNullOrWhiteSpace(parameter))
        {
            throw new ArgumentException(message ?? "Parameter is null or whitespace!", parameterName);
        }

        return parameter;
    }

    #endregion

    #region int 

    /// <summary>
    /// Handling the integer is negative check null or whitespace check and throw a ArgumentException
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="value">the value to check</param>
    /// <param name="message">a optional message instead of the default</param>
    public static int ThrowIfLessOrEqual(this int parameter, string parameterName, int value, string? message = null)
    {
        if (parameter <= value)
        {
            throw new ArgumentException(message ?? $"Parameter is less or equal to {value}!", parameterName);
        }

        return parameter;
    }

    #endregion

    #region CancellationToken

    /// <summary>
    /// Handling the none check and throw a ArgumentException if CancellationToken.None
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static CancellationToken ThrowIfNone(this CancellationToken parameter, string parameterName, string? message = null)
    {
        if (parameter == CancellationToken.None)
        {
            throw new ArgumentException(message ?? "Parameter is none!", parameterName);
        }

        return parameter;
    }

    #endregion
}