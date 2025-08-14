using AselBlazorCleanArchitecture.Infrastructure.Data.CleanPattern;
using AselBlazorCleanArchitecture.Server.Components;
using AselBlazorCleanArchitecture.Server.Extensions;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IDBContextFactory, DbContextFactory>();


builder.Services.AddMudServices();
builder.Services.AddControllers();
builder.Services.AddAntiforgery();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies");

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

builder.Services.AddLoggingServices();

builder.Services.AddScoped(sp =>
{
    var configUrl = builder.Configuration["SystemURL:BaseURLFromAppSettings"];
    var baseUrl = !string.IsNullOrWhiteSpace(configUrl)
        ? configUrl
        : "https://localhost:44332/"; // Change this to your default URL if not set in appsettings.json

    return new HttpClient
    {
        BaseAddress = new Uri(baseUrl),
        Timeout = TimeSpan.FromMinutes(30)
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

//Serilog
app.UseSerilogRequestLogging();

app.Run();
