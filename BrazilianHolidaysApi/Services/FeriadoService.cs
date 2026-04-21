using BrazilianHolidaysApi.DTOs;
using BrazilianHolidaysApi.Enums;
using BrazilianHolidaysApi.Exceptions;
using BrazilianHolidaysApi.Interfaces;
using BrazilianHolidaysApi.Models;


namespace BrazilianHolidaysApi.Services;

public class FeriadoService : IFeriadoService
{
    private readonly IFeriadoRepository _repository;

    // O banco tem dados do ano atual até anoAtual + 5
    private static readonly int AnoMinimo = DateTime.Today.Year;
    private static readonly int AnoMaximo = DateTime.Today.Year + 5;

    public FeriadoService(IFeriadoRepository repository)
    {
        _repository = repository;
    }

    private static FeriadoDto ParaDto(Feriado f) => new FeriadoDto
    {
        Nome = f.Nome,
        Data = f.Data,
        Tipo = f.Tipo,
        UF = f.UF,
        Descricao = f.Descricao
    };

    private void ValidarAno(int ano)
    {
        if (ano < AnoMinimo || ano > AnoMaximo)
            throw new NegocioException($"Ano fora do intervalo disponível. Consulte entre {AnoMinimo} e {AnoMaximo}.");
    }

    public async Task<IEnumerable<FeriadoDto>> ObterNacionaisAsync(int ano)
    {
        ValidarAno(ano);
        var feriados = await _repository.ObterPorAnoETipoAsync(ano, TipoFeriado.Nacional);
        return feriados.Select(ParaDto);
    }
    public async Task<IEnumerable<FeriadoDto>> ObterPorUFAsync(int ano, string uf)
    {
        ValidarAno(ano);

        var ufUpper = uf.ToUpper();

        // Valida se a UF existe no banco antes de buscar tudo
        var ufExiste = await _repository.ExisteUFAsync(ufUpper);
        if (!ufExiste)
            throw new NegocioException($"UF '{ufUpper}' não encontrada. Verifique se a sigla está correta.");

        var feriados = await _repository.ObterPorAnoEUFAsync(ano, ufUpper);
        return feriados.Select(ParaDto);
    }

    public async Task<FeriadoDto?> ObterProximoFeriadoAsync()
    {
        var feriado = await _repository.ObterProximoFeriadoAsync();
        if (feriado is null) return null;
        return ParaDto(feriado);
    }

}