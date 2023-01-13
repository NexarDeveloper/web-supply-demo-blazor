using StrawberryShake;
using System;
using System.Diagnostics;
using System.Text;

namespace Nexar.Client;

public static class IOperationResult_AssertNoErrors
{
    /// <summary>
    /// Checks the operation result and throws an exception on errors.
    /// </summary>
    [DebuggerHidden]
    public static void AssertNoErrors(this IOperationResult result)
    {
        if (result.Errors.Count == 0)
            return;

        var sb = new StringBuilder();

        if (result.Errors.Count > 1)
            sb.AppendLine($"Error 1/{result.Errors.Count}:");

        var error = result.Errors[0];
        sb.AppendLine($"Message: {error.Message}");

        if (error.Path != null && error.Path.Count > 0)
        {
            sb.Append($"Path: ");
            foreach (var item in error.Path)
                sb.Append($"/{item}");
            sb.AppendLine();
        }

        var message = sb.ToString();
        throw new Exception(message);
    }
}
