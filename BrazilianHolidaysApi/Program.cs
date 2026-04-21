using BrazilianHolidays.Data.Seed;
using BrazilianHolidaysApi.Data.Context;
using BrazilianHolidaysApi.Data.Repositories;
using BrazilianHolidaysApi.Interfaces;
using BrazilianHolidaysApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Porta do Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=brazilianholidays.db"));

// Injeção de dependência
builder.Services.AddScoped<IFeriadoRepository, FeriadoRepository>();
builder.Services.AddScoped<IFeriadoService, FeriadoService>();

var app = builder.Build();

// Swagger disponível sempre (útil para portfólio)
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

// Seed do banco de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    FeriadoSeed.Popular(context);
}

app.Run();