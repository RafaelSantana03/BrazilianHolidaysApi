using BrazilianHolidays.Application.DTOs;
using BrazilianHolidays.Domain.Enums;
using BrazilianHolidays.Domain.Interfaces;

namespace BrazilianHolidays.Application.Services;

public class FeriadoService
{
    private readonly IFeriadoRepository _repository;
    private readonly IBrasilApiService _brasilApiService;

    public FeriadoService(IFeriadoRepository repository, IBrasilApiService brasilApiService)
    {
        _repository = repository;
        _brasilApiService = brasilApiService;
    }

    private async Task GarantirDadosParaAnoAsync(int ano)
    {
        var existeDados = await _repository.ExisteParaAnoAsync(ano);
        if (!existeDados)
        {
            var feriados = await _brasilApiService.ObterFeriadosAsync(ano);
            await _repository.AdicionarVariosAsync(feriados);
        }
    }

    private static FeriadoDto ParaDto(Domain.Entities.Feriado f) => new FeriadoDto
    {
        Nome = f.Nome,
        Data = f.Data,
        Tipo = f.Tipo,
        UF = f.UF,
        Descricao = f.Descricao
    };

    public async Task<IEnumerable<FeriadoDto>> ObterTodosPorAnoAsync(int ano)
    {
        await GarantirDadosParaAnoAsync(ano);
        var feriados = await _repository.ObterTodosPorAnoAsync(ano);
        return feriados.Select(ParaDto);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterNacionaisAsync(int ano)
    {
        await GarantirDadosParaAnoAsync(ano);
        var feriados = await _repository.ObterPorAnoETipoAsync(ano, TipoFeriado.Nacional);
        return feriados.Select(ParaDto);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterPorUFAsync(int ano, string uf)
    {
        await GarantirDadosParaAnoAsync(ano);
        var feriados = await _repository.ObterPorAnoEUFAsync(ano, uf.ToUpper());
        return feriados.Select(ParaDto);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterPorMunicipioAsync(int ano, int codigoIbge)
    {
        await GarantirDadosParaAnoAsync(ano);
        var feriados = await _repository.ObterPorAnoEMunicipioAsync(ano, codigoIbge);
        return feriados.Select(ParaDto);
    }

    public async Task<FeriadoDto?> ObterProximoFeriadoAsync()
    {
        await GarantirDadosParaAnoAsync(DateTime.Today.Year);
        var feriado = await _repository.ObterProximoFeriadoAsync();
        if (feriado is null) return null;
        return ParaDto(feriado);
    }

    public async Task<IEnumerable<FeriadoDto>> ObterPontosFacultativosAsync(int ano)
    {
        await GarantirDadosParaAnoAsync(ano);
        var feriados = await _repository.ObterPorAnoETipoAsync(ano, TipoFeriado.PontoFacultativo);
        return feriados.Select(ParaDto);
    }
}