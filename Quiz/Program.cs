using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Extensions.LocalStorage;
using Quiz;
using Quiz.State;
using Share;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://exe-backend-j428.onrender.com")
});
builder.Services.AddHttpClient(Constant.Client, client =>
{
    client.BaseAddress = new Uri("https://exe-backend-j428.onrender.com");
});
builder.Services.AddHttpClient("FastApiClient", client =>
{
    client.BaseAddress = new Uri("https://exe-createquiz.onrender.com");
});
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthState>();
builder.Services.AddAuthorizationCore();
builder.Services.AddNetcodeHubLocalStorageService();

await builder.Build().RunAsync();
