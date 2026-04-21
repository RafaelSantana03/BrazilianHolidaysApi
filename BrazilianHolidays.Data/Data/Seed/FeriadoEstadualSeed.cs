using BrazilianHolidays.Domain.Entities;
using BrazilianHolidays.Domain.Enums;

namespace BrazilianHolidays.Data.Seed;

public static class FeriadoEstadualSeed
{
    public static IEnumerable<Feriado> Gerar(int anoInicio, int anoFim)
    {
        var feriados = new List<Feriado>();

        // estados serão adicionados aqui
        for (int ano = anoInicio; ano <= anoFim; ano++)
        {
            // Espírito Santo
            feriados.Add(new Feriado { Nome = "Nossa Senhora da Penha", Data = new DateOnly(ano, 4, 13), Tipo = TipoFeriado.Estadual, UF = "ES", Recorrente = true, Descricao = "Padroeira do Espírito Santo" });
        }

        return feriados;
    }
}