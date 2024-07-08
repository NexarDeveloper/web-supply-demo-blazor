using StrawberryShake;
using System;
using System.Diagnostics;
using System.Text;

namespace Nexar.Client;

public static class IOperationResult_AssertNoErrors
{
    /// <summary>
    /// Checks the operation result for no errors and returns its data, never null.
    /// </summary>
    [DebuggerHidden]
    public static T AssertNoErrors<T>(this IOperationResult<T> result) where T : class
    {
        return AssertNoErrorsAnyData(result) ?? throw new Exception("Unexpected null data.");
    }

    /// <summary>
    /// Checks the operation result for no errors and returns its data, maybe null.
    /// </summary>
    [DebuggerHidden]
    public static T? AssertNoErrorsAnyData<T>(this IOperationResult<T> result) where T : class
    {
        if (result.Errors.Count == 0)
            return result.Data;

        var sb = new StringBuilder();

        if (result.Errors.Count > 1)
            sb.AppendLine($"Error 1/{result.Errors.Count}:");

        var error = result.Errors[0];
        sb.AppendLine($"Message: {error.Message}");

        if (error.Path?.Count > 0)
        {
            sb.Append($"Path: ");
            foreach (var item in error.Path)
                sb.Append($"/{item}");
            sb.AppendLine();
        }

        if (result.Extensions is { } ext && ext.TryGetValue("requestId", out object? requestId))
            sb.AppendLine($"requestId: {requestId}");

        var message = sb.ToString();
        throw new Exception(message);
    }
}
