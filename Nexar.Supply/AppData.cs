using System;

namespace Nexar.Supply;

/// <summary>
/// The application parameters and state.
/// </summary>
public static class AppData
{
    /// <summary>
    /// The identity server endpoint.
    /// </summary>
    public const string Authority = "https://identity.nexar.com/";

    /// <summary>
    /// The Nexar GraphQL API endpoint.
    /// </summary>
    public const string ApiEndpoint = "https://api.nexar.com/graphql";

    /// <summary>
    /// The Nexar home page.
    /// </summary>
    public const string NexarDotCom = "https://nexar.com";

    /// <summary>
    /// The current session token.
    /// </summary>
    public static string? Token
    {
        get => _token;
        set
        {
            _token = value;
            OnChange?.Invoke();
        }
    }
    private static string? _token;

    /// <summary>
    /// This event is triggered on changes.
    /// </summary>
    public static event Action? OnChange;
}
