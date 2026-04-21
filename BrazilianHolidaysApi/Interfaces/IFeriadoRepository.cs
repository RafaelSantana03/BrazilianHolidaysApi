
using BrazilianHolidaysApi.Models;
using BrazilianHolidaysApi.Enums;

namespace BrazilianHolidaysApi.Interfaces;

public interface IFeriadoRepository
{
    Task<IEnumerable<Feriado>> ObterPorAnoETipoAsync(int ano, TipoFeriado tipo);
    Task<IEnumerable<Feriado>> ObterPorAnoEUFAsync(int ano, string uf);
    Task<Feriado?> ObterProximoFeriadoAsync();
    Task AdicionarAsync(Feriado feriado);
    Task AdicionarVariosAsync(IEnumerable<Feriado> feriados);
    Task<bool> ExisteParaAnoAsync(int ano);
    Task<bool> ExisteUFAsync(string uf);
}
