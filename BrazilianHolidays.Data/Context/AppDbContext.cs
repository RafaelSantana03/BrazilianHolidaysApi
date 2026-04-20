
using BrazilianHolidays.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrazilianHolidays.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }
    public DbSet<Feriado> Feriados { get; set; }
}
