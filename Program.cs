using Supabase;
using BlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args);

// Configuración del cliente de Supabase
builder.Services.AddSingleton<Supabase.Client>(provider =>
    new Supabase.Client("https://ojobsiymufclslkrcqaz.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9qb2JzaXltdWZjbHNsa3JjcWF6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzc2ODA4MDksImV4cCI6MjA1MzI1NjgwOX0.BPGbGACsbtMQqBFnMKN_r_DRGaaLRn_shnleXQCgNhw"));

// Agregar servicios
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configuración del pipeline de solicitudes
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
