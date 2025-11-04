using Microsoft.EntityFrameworkCore;
using P2_AP1_RonnelDeLaCruz.Components;
using P2_AP1_RonnelDeLaCruz.DAL;
using P2_AP1_RonnelDeLaCruz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContextFactory<Contexto>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<PedidosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
