using BrazilianHolidays.Application.DTOs;
using BrazilianHolidays.Domain.Enums;
using BrazilianHolidays.Domain.Interfaces;

namespace BrazilianHolidays.Application.Services;

public class FeriadoService
{
    private readonly IFeriadoRepository _repository;

    public FeriadoService(IFeriadoRepository repository)
    {
        _repository = repository;
    }

    private static FeriadoDto ParaDto(Domain.Entities.Feriado f) => new FeriadoDto
    {
        Nome = f.Nome,
        Data = f.Data,
        Tipo = f.Tipo,
        UF = f.UF,
        Descricao = f.Descricao
    };

    public async Task<IEnumerable<FeriadoDto>> ObterNacionaisAsync(int ano)
    {
        var feriados = await _repository.ObterPorAnoETipoAsync(ano, TipoFeriado.Nacional);
        return feriados.Select(ParaDto);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterPorUFAsync(int ano, string uf)
    {
        var feriados = await _repository.ObterPorAnoEUFAsync(ano, uf.ToUpper());
        return feriados.Select(ParaDto);
    }

    public async Task<FeriadoDto?> ObterProximoFeriadoAsync()
    {
        var feriado = await _repository.ObterProximoFeriadoAsync();
        if (feriado is null) return null;
        return ParaDto(feriado);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterPontosFacultativosAsync(int ano)
    {
        var feriados = await _repository.ObterPorAnoETipoAsync(ano, TipoFeriado.PontoFacultativo);
        return feriados.Select(ParaDto);
    }
}