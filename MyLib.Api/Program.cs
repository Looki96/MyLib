using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using NLog.Web;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyLib.Api.Entities;
using System;
using System.Text.Json;
using System.Reflection.Emit;
using Microsoft.Extensions.DependencyInjection;
using MyLib.Api.Seeders;
using Microsoft.AspNetCore.Identity;
using MyLib.Api.Services.Factory;
using MyLib.Api.Middleware;
using MyLib.Api.Services;
using MyLib.Api;
using Microsoft.AspNetCore.Authorization;
using MyLib.Api.Authorization;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddDbContext<MyLibContext>(options =>
{
    options.UseInMemoryDatabase("MyLibDB");
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAuthorizationHandler, BorrowOperationRequirementHandler>();

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBorrowService, BorrowService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddScoped<ISettingService, SettingService>();

builder.Services.AddScoped<IUserContextService, UserContextService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<ErrorHandler>();

builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:7025", "https://localhost:7025")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

AddCustomerData(app);

app.UseMiddleware<ErrorHandler>();

app.UseCors();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();

    SettingsSeeder.Seed(scope.ServiceProvider);
    RolesSeeder.Seed(scope.ServiceProvider);
    UsersSeeder.Seed(scope.ServiceProvider);
    CategoriesSeeder.Seed(scope.ServiceProvider);
    AuthorsSeeder.Seed(scope.ServiceProvider);
    PublishersSeeder.Seed(scope.ServiceProvider);
    BooksSeeder.Seed(scope.ServiceProvider);
}
