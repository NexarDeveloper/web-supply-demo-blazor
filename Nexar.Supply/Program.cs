using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Nexar.Supply;
using System;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services
    .AddMudServices()
    .AddNexarClient()
    .ConfigureHttpClient((sp, client) =>
    {
        // throw on null token, the handler navigates to login
        if (AppData.Token is null)
            throw new Exception("Please login.");

        client.BaseAddress = new Uri(AppData.ApiEndpoint);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppData.Token);
    })
;

await builder.Build().RunAsync();
