using BlazorApp.Client.Pages;
using BlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.Use((c, n) =>
        {
            if (c.Request.Path.StartsWithSegments("/spa1")
            && !c.Request.Path.Value.Contains("."))
            {
                c.Request.Path = "/spa1/index.html";
            }
            return n();
        });
        
app.Use((c, n) =>
{
    if (c.Request.Path.StartsWithSegments("/spa2")
            && !c.Request.Path.Value.Contains("."))
            {
                c.Request.Path = "/spa2/index.html";
            }
    return n();
});

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.Run();
