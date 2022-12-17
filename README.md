# Nexar.Supply Demo

Demo Blazor WebAssembly with supply queries powered by Nexar.

Live demo: [https://web-supply-demo.nexar.com](https://web-supply-demo.nexar.com)

## How to use

[nexar.com]: https://nexar.com/

In order to use the app you need an organization at [nexar.com] and one of its
applications with Supply enabled. Use this application client ID and secret as
credentials for Nexar.Supply.

At the sign in page enter your Nexar client ID and secret and click `SIGN IN`.
Save the password when prompted, to allow auto completion next time.

After that the following page links are shown in the navigation menu:

- Search
- Attributes
- Categories
- Manufactures
- Sellers

## Building blocks

[Blazor]: https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
[MudBlazor]: https://github.com/Garderoben/MudBlazor

The app is built with [Blazor] using [MudBlazor] components.

The Supply domain data are provided by Nexar API: <https://api.nexar.com/graphql>.
This is the endpoint for GraphQL queries and also "Banana Cake Pop", the GraphQL IDE.

The package [HotChocolate StrawberryShake](https://github.com/ChilliCream/hotchocolate)
is used for generating strongly typed C# client code for invoking GraphQL queries.
See the source queries in [Resources](Nexar.Client/Resources).
