using Microsoft.AspNetCore.Components;
using MudBlazor;
using StrawberryShake;
using System;
using System.Threading.Tasks;

namespace Nexar.Supply.Pages
{
    /// <summary>
    /// Common base page with handy members.
    /// </summary>
    public partial class AbstractPage : ComponentBase
    {
        /// <summary>
        /// Modal message boxes.
        /// </summary>
        [Inject] private IDialogService DialogService { get; set; }

        /// <summary>
        /// Common navigation manager.
        /// </summary>
        [Inject] public NavigationManager NavManager { get; init; }

        /// <summary>
        /// The application state.
        /// </summary>
        [Inject] public AppData AppData { get; init; }

        /// <summary>
        /// Check the operation result and throw on any errors.
        /// </summary>
        public static void EnsureNoErrors(IOperationResult result)
        {
            if (result.Errors.Count == 0)
                return;

            var sb = new System.Text.StringBuilder();
            foreach (var error in result.Errors)
            {
                sb.AppendLine($"ERROR: {error.Message}");
                if (error.Code != null)
                    sb.AppendLine($"Code: {error.Code}");
                if (error.Extensions != null)
                {
                    foreach (var kv in error.Extensions)
                        sb.AppendLine($"{kv.Key}: {kv.Value}");
                }
            }

            var message = sb.ToString();
            throw new Exception(message);
        }

        /// <summary>
        /// Show the message, logout, navigate to login page.
        /// </summary>
        public async Task ShowErrorAsync(string message)
        {
            await DialogService.ShowMessageBox("Error", message);

            AppData.Token = null;
            NavManager.NavigateTo("");
        }
    }
}
