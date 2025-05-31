using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddDbContext<Contexto>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ConexãoPadrão"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexãoPadrão"))
    )
);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(); // Suporte para MVC + Views

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseDefaultFiles(); // Se tiver login.html, etc.
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // 🔸 Necessário antes do UseEndpoints

app.UseAuthorization();

// 🔸 Aqui configura tanto a API quanto a rota MVC
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // API
    //endpoints.MapDefaultControllerRoute(); // MVC
});

app.Run();
