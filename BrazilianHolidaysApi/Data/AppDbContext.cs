using BrazilianHolidaysApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrazilianHolidaysApi.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }
    public DbSet<Feriado> Feriados { get; set; }
}
