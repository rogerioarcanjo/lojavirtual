using Blazored.LocalStorage;
using BlazorShop.Web;
using BlazorShop.Web.Authentication; // Adicione o namespace para CustomAuthenticationStateProvider
using BlazorShop.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using FluentAssertions.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7150";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGerenciaProdutosLocalStorageService, GerenciaProdutosLocalStorageService>();
builder.Services.AddScoped<IGerenciaCarrinhoItensLocalStorageService, GerenciaCarrinhoItensLocalStorageService>();

builder.Services.AddAuthorizationCore(); // Adiciona suporte à autorização

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddScoped<UsuarioService>();

await builder.Build().RunAsync();