using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyLib.UI;
using MyLib.UI.Authentication;
using MyLib.UI.Services;
using MyLib.UI.Services.Factory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7062") });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBorrowService, BorrowService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddScoped<ISettingService, SettingService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
