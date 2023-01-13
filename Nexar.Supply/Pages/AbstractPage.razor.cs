using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace Nexar.Supply.Pages;

/// <summary>
/// Common base page with handy members.
/// </summary>
public class AbstractPage : ComponentBase
{
    /// <summary>
    /// Modal message boxes.
    /// </summary>
    [Inject]
    private IDialogService DialogService { get; init; }

    /// <summary>
    /// Common navigation manager.
    /// </summary>
    [Inject]
    public NavigationManager NavManager { get; init; }

    /// <summary>
    /// Show the message, logout, navigate to login page.
    /// </summary>
    public async Task ShowErrorAndResetAsync(string message)
    {
        await DialogService.ShowMessageBox("Error", message);

        AppData.Token = null;
        NavManager.NavigateTo("");
    }
}
