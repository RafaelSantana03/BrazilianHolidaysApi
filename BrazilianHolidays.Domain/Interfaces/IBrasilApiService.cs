using BrazilianHolidays.Domain.Entities;

namespace BrazilianHolidays.Domain.Interfaces;

public interface IBrasilApiService
{
    Task<IEnumerable<Feriado>> ObterFeriadosAsync(int ano);
}