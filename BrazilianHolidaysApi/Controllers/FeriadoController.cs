using BrazilianHolidaysApi.Exceptions;
using BrazilianHolidaysApi.Interfaces;
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
        if (ano <= 0)
            return BadRequest("Ano inválido.");
        try
        {
            var feriados = await _service.ObterNacionaisAsync(ano);
            return Ok(feriados);
        }
        catch (NegocioException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{ano}/estado/{uf}")]
    public async Task<IActionResult> ObterPorUF(int ano, string uf)
    {
        if (ano <= 0)
            return BadRequest("Ano inválido.");
        if (uf.Length != 2 || !uf.All(char.IsLetter))
            return BadRequest("UF inválida. Deve conter 2 letras.");
        try
        {
            var feriados = await _service.ObterPorUFAsync(ano, uf);
            return Ok(feriados);
        }
        catch (NegocioException ex)
        {
            return BadRequest(ex.Message);
        }
        
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