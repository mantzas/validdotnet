using System.Runtime.CompilerServices;

namespace ValidDotNet;

public static class CancellationTokenExtensions
{
    /// <summary>
    ///     Handling the none check and throw a ArgumentException if CancellationToken.None
    /// </summary>
    /// <param name="parameter">the actual parameter</param>
    /// <param name="parameterName">the name of the parameter</param>
    /// <param name="message">a optional message instead of the default</param>
    public static CancellationToken ThrowIfNone(this CancellationToken parameter,
        [CallerArgumentExpression("parameter")] string parameterName = "",
        string? message = null)
    {
        if (parameter == CancellationToken.None)
            throw new ArgumentException(message ?? "Parameter is none!", parameterName);

        return parameter;
    }
}