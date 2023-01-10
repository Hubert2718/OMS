global using OMS.Shared;
global using OMS.Client.Services.OrderService;
global using System.Net.Http.Json;
global using OMS.Client.Services.StatusService;
global using OMS.Client.Services.ClientService;
global using OMS.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using OMS.Client.Services.UserService;
global using OMS.Client.Services.ProductService;
global using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OMS.Client;
using Blazored.LocalStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
