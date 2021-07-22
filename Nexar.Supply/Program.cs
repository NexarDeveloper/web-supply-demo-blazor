using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Threading.Tasks;

namespace Nexar.Supply
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddMudServices()
                .AddSingleton<AppData>()
                .AddNexarClient()
                .ConfigureHttpClient((sp, client) =>
                {
                    var appData = sp.GetService<AppData>();

                    // get and check the token, throw if null,
                    // the handler will navigate to login page
                    var token = appData.Token;
                    if (token == null)
                        throw new Exception("Please login.");

                    client.BaseAddress = new Uri(appData.ApiEndpoint);
                    client.DefaultRequestHeaders.Add("token", token);
                })
            ;

            await builder.Build().RunAsync();
        }
    }
}
