# Nexar.Supply Demo

Demo Blazor WebAssembly with supply queries powered by Nexar.

Live demo: [https://web-supply-demo.nexar.com](https://web-supply-demo.nexar.com)

## How to use

[nexar.com]: https://nexar.com/

In order to use the app you need an organization at [nexar.com] and one of its
applications with Supply enabled. Use this application client ID and secret as
credentials for Nexar.Supply.

At the login page enter your Nexar client ID and secret and click `Login`.
Save the password when prompted, to allow auto completion next time.

On successful login the following page links are shown in the side bar:

- Search
- Attributes
- Categories
- Manufactures
- Sellers

## Building blocks

[Blazor]: https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
[Blazorise]: https://github.com/Megabit/Blazorise

The app is built with [Blazor] using [Blazorise] components.

The Supply domain data are provided by Nexar API: <https://api.nexar.com/graphql>.
This is the GraphQL endpoint for queries and also the Banana Cake Pop GraphQL IDE in browsers.

The [HotChocolate StrawberryShake](https://github.com/ChilliCream/hotchocolate) package
is used for generating strongly typed C# client code for invoking GraphQL queries.
See the source queries in [Resources](Nexar.Supply/GraphQL/Resources).
