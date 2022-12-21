using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class TimeSpanExtensions
{
    /// <summary>
    ///     Handling the zero check and throw a ArgumentException if TimeSpan.Zero
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static TimeSpan ThrowIfZero(this TimeSpan parameter,
        [CallerArgumentExpression("parameter")] string parameterName = "", string? message = null)
    {
        if (parameter == TimeSpan.Zero) throw new ArgumentException(message ?? "Parameter is zero!", parameterName);

        return parameter;
    }
}