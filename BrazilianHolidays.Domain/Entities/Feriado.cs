using BrazilianHolidays.Domain.Enums;

namespace BrazilianHolidays.Domain.Entities;

public class Feriado
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty; // Tornando a propriedade obrigatória
    public DateOnly Data { get; set; }
    public TipoFeriado Tipo { get; set; }
    public bool Recorrente { get; set; }
    public string? UF { get; set; }
    public int? CodigoIbgeMunicipio { get; set; }
    public string? Descricao { get; set; }

}
