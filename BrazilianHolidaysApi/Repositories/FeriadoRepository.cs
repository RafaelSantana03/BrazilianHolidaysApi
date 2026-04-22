using BrazilianHolidaysApi.Models;
using BrazilianHolidaysApi.Enums;
using BrazilianHolidaysApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using BrazilianHolidaysApi.Data.Context;

namespace BrazilianHolidaysApi.Data.Repositories;

public class FeriadoRepository : IFeriadoRepository
{
    private readonly AppDbContext _context;
    public FeriadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Feriado>> ObterPorAnoETipoAsync(int ano, TipoFeriado tipo)
    {
        return await _context.Feriados
            .Where(f => f.Data.Year == ano && f.Tipo == tipo)
            .OrderBy(f => f.Data)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feriado>> ObterPorAnoEUFAsync(int ano, string uf)
    {
        return await _context.Feriados
            .Where(f => f.Data.Year == ano &&
            (f.Tipo == TipoFeriado.Nacional ||
            (f.Tipo == TipoFeriado.Estadual && f.UF == uf)))
            .OrderBy(f => f.Data)
            .ToListAsync();
    }

    public async Task<Feriado?> ObterProximoFeriadoAsync()
    {
        var hoje = DateOnly.FromDateTime(DateTime.Today);
        return await _context.Feriados
            .Where(f => f.Data >= hoje && f.Tipo == TipoFeriado.Nacional)
            .OrderBy(f => f.Data)
            .FirstOrDefaultAsync();
    }

    public async Task AdicionarAsync(Feriado feriado)
    {
        await _context.Feriados.AddAsync(feriado);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarVariosAsync(IEnumerable<Feriado> feriados)
    {
        await _context.Feriados.AddRangeAsync(feriados);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExisteParaAnoAsync(int ano)
    {
        return await _context.Feriados.AnyAsync(f => f.Data.Year == ano);
    }

    public async Task<bool> ExisteUFAsync(string uf)
    {
        return await _context.Feriados
        .AnyAsync(f => f.Tipo == TipoFeriado.Estadual && f.UF == uf);
    }
}
