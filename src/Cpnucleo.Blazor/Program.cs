using Cpnucleo.Blazor;
using Cpnucleo.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddRefitClient<ICpnucleoApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{builder.Configuration.GetValue<string>("AppSettings:UrlCpnucleoApi")}/api/v2"));

await builder.Build().RunAsync();