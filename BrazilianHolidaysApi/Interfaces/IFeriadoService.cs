using BrazilianHolidaysApi.DTOs;
using BrazilianHolidaysApi.Models;

namespace BrazilianHolidaysApi.Interfaces;

public interface IFeriadoService
{
    Task<IEnumerable<FeriadoDto>> ObterNacionaisAsync(int ano);
    Task<IEnumerable<FeriadoDto>> ObterPorUFAsync(int ano, string uf);
    Task<FeriadoDto?> ObterProximoFeriadoAsync();
}