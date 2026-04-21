using System.Text.Json;
using BrazilianHolidays.Data.DTOs;
using BrazilianHolidays.Domain.Entities;
using BrazilianHolidays.Domain.Enums;
using BrazilianHolidays.Domain.Interfaces;

namespace BrazilianHolidays.Data.ExternalServices;

public class BrasilApiService : IBrasilApiService
{
    private readonly HttpClient _httpClient;

    public BrasilApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Feriado>> ObterFeriadosAsync(int ano)
    {
        var url = $"https://brasilapi.com.br/api/feriados/v1/{ano}";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return Enumerable.Empty<Feriado>();

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var feriadosApi = JsonSerializer.Deserialize<List<BrasilApiFeriadoDto>>(json, options)
            ?? new List<BrasilApiFeriadoDto>();

        return feriadosApi.Select(f => new Feriado
        {
            Nome = f.Name,
            Data = DateOnly.Parse(f.Date),
            Tipo = TipoFeriado.Nacional,
            Recorrente = false,
            Descricao = f.Type
        });
    }
}