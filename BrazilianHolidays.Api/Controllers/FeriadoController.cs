using BrazilianHolidays.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrazilianHolidays.Api.Controllers;

[ApiController]
[Route("v1/feriados")]
public class FeriadoController : ControllerBase
{
    private readonly FeriadoService _service;

    public FeriadoController(FeriadoService service)
    {
        _service = service;
    }

    [HttpGet("{ano}")]
    public async Task<IActionResult> ObterTodos(int ano)
    {
        var feriados = await _service.ObterTodosPorAnoAsync(ano);
        return Ok(feriados);
    }

    [HttpGet("{ano}/nacionais")]
    public async Task<IActionResult> ObterNacionais(int ano)
    {
        var feriados = await _service.ObterNacionaisAsync(ano);
        return Ok(feriados);
    }

    [HttpGet("{ano}/estado/{uf}")]
    public async Task<IActionResult> ObterPorUF(int ano, string uf)
    {
        var feriados = await _service.ObterPorUFAsync(ano, uf);
        return Ok(feriados);
    }

    [HttpGet("{ano}/municipio/{codigoIbge}")]
    public async Task<IActionResult> ObterPorMunicipio(int ano, int codigoIbge)
    {
        var feriados = await _service.ObterPorMunicipioAsync(ano, codigoIbge);
        return Ok(feriados);
    }

    [HttpGet("proximo")]
    public async Task<IActionResult> ObterProximo()
    {
        var feriado = await _service.ObterProximoFeriadoAsync();
        if (feriado is null)
            return NotFound("Nenhum feriado encontrado.");
        return Ok(feriado);
    }

    [HttpGet("{ano}/pontos-facultativos")]
    public async Task<IActionResult> ObterPontosFacultativos(int ano)
    {
        var feriados = await _service.ObterPontosFacultativosAsync(ano);
        return Ok(feriados);
    }
}