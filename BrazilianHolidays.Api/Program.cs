using BrazilianHolidays.Application.Services;
using BrazilianHolidays.Data.Context;
using BrazilianHolidays.Data.Repositories;
using BrazilianHolidays.Data.Seed;
using BrazilianHolidays.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<FeriadoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed do banco de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    FeriadoSeed.Popular(context);
}


app.Run();