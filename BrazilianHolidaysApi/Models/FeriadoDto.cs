using BrazilianHolidaysApi.Enums;

namespace BrazilianHolidaysApi.DTOs;

public class FeriadoDto
{
    public string Nome { get; set; } = string.Empty;
    public DateOnly Data { get; set; }
    public TipoFeriado Tipo { get; set; }
    public string? UF { get; set; }
    public string? Descricao { get; set; }
}