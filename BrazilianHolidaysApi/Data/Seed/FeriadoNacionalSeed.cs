using BrazilianHolidaysApi.Models;
using BrazilianHolidaysApi.Enums;

namespace BrazilianHolidaysApi.Data.Seed;

public static class FeriadoNacionalSeed
{
    public static IEnumerable<Feriado> Gerar(int anoInicio, int anoFim)
    {
        var feriados = new List<Feriado>();

        for (int ano = anoInicio; ano <= anoFim; ano++)
        {
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Ano Novo", Data = new DateOnly(ano, 1, 1), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Confraternização Universal" },
                new Feriado { Nome = "Tiradentes", Data = new DateOnly(ano, 4, 21), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Dia de Tiradentes" },
                new Feriado { Nome = "Dia do Trabalho", Data = new DateOnly(ano, 5, 1), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Dia Internacional do Trabalho" },
                new Feriado { Nome = "Independência do Brasil", Data = new DateOnly(ano, 9, 7), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Independência do Brasil" },
                new Feriado { Nome = "Nossa Senhora Aparecida", Data = new DateOnly(ano, 10, 12), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Padroeira do Brasil" },
                new Feriado { Nome = "Finados", Data = new DateOnly(ano, 11, 2), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Dia de Finados" },
                new Feriado { Nome = "Proclamação da República", Data = new DateOnly(ano, 11, 15), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Proclamação da República" },
                new Feriado { Nome = "Consciência Negra", Data = new DateOnly(ano, 11, 20), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Dia da Consciência Negra" },
                new Feriado { Nome = "Natal", Data = new DateOnly(ano, 12, 25), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Natal" },
            });

            var pascoa = PascoaHelper.Calcular(ano);
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Carnaval", Data = pascoa.AddDays(-47), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Carnaval" },
                new Feriado { Nome = "Sexta-feira Santa", Data = pascoa.AddDays(-2), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Paixão de Cristo" },
                new Feriado { Nome = "Páscoa", Data = pascoa, Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Páscoa" },
                new Feriado { Nome = "Corpus Christi", Data = pascoa.AddDays(60), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Corpus Christi" },
                new Feriado { Nome = "Véspera de Natal", Data = new DateOnly(ano, 12, 24), Tipo = TipoFeriado.PontoFacultativo, Recorrente = true, Descricao = "Véspera de Natal" },
                new Feriado { Nome = "Véspera de Ano Novo", Data = new DateOnly(ano, 12, 31), Tipo = TipoFeriado.PontoFacultativo, Recorrente = true, Descricao = "Véspera de Ano Novo" },
                new Feriado { Nome = "Terça-feira de Carnaval", Data = pascoa.AddDays(-48), Tipo = TipoFeriado.PontoFacultativo, Recorrente = false, Descricao = "Terça-feira de Carnaval" },
            });
        }

        return feriados;
    }
}