using Microsoft.EntityFrameworkCore;
using APISeries.Models.EntityFramework; // Vérifie que ce namespace correspond bien à tes fichiers générés

var builder = WebApplication.CreateBuilder(args);

// 1. Ajouter les contrôleurs et Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Injection de dépendance pour la base de données (PostgreSQL)
builder.Services.AddDbContext<SeriesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContext")));

var app = builder.Build();

// 3. Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4. Activer les CORS (Indispensable pour que ton futur client WinUI puisse appeler l'API)
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();