using System.Reflection;
using Masa.Docs.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<LazyAssemblyLoader>();
builder.Services.AddMasaBlazor(options =>
{
    options.ConfigureTheme(theme =>
    {
        theme.Themes.Light.Secondary = "#5CBBF6";
        theme.Themes.Light.Accent = "#005CAF";
        theme.Themes.Light.UserDefined["Tertiary"] = "#e57373";
    });
});

// TODO: add i18n for server

// TODO: add MasaBlazorDocs

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
var executePath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(App)).Location);
var currentPath = Directory.GetCurrentDirectory();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Sources")),
});

app.UseRouting();

// TODO: crawlService

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
