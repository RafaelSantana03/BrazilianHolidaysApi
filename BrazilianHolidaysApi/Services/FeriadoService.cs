using BrazilianHolidaysApi.DTOs;
using BrazilianHolidaysApi.Enums;
using BrazilianHolidaysApi.Interfaces;

namespace BrazilianHolidaysApi.Services;

public class IFeriadoService
{
    private readonly IFeriadoRepository _repository;

    public IFeriadoService(IFeriadoRepository repository)
    {
        _repository = repository;
    }

    private static FeriadoDto ParaDto(BrazilianHolidaysApi.Models.Feriado f) => new FeriadoDto
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