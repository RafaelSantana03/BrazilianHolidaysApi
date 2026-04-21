using BrazilianHolidaysApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrazilianHolidaysApi.Controllers;

[ApiController]
[Route("v1/feriados")]
public class FeriadoController : ControllerBase
{
    private readonly IFeriadoService _service;

    public FeriadoController(IFeriadoService service)
    {
        _service = service;
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

    [HttpGet("proximo")]
    public async Task<IActionResult> ObterProximo()
    {
        var feriado = await _service.ObterProximoFeriadoAsync();
        if (feriado is null)
            return NotFound("Nenhum feriado encontrado.");
        return Ok(feriado);
    }

}