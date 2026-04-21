using BrazilianHolidays.Domain.Entities;
using BrazilianHolidays.Domain.Enums;
using BrazilianHolidays.Data.Context;

namespace BrazilianHolidays.Data.Seed;

public static class FeriadoSeed
{
    public static void Popular(AppDbContext context)
    {
        if (context.Feriados.Any())
            return;

        var anoAtual = DateTime.Today.Year;
        var feriados = new List<Feriado>();

        // Feriados fixos nacionais (mesma data todo ano)
        for (int ano = anoAtual; ano <= anoAtual + 5; ano++)
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
                new Feriado { Nome = "Natal", Data = new DateOnly(ano, 12, 25), Tipo = TipoFeriado.Nacional, Recorrente = true, Descricao = "Natal" },
            });

            // Feriados móveis (calculados a partir da Páscoa)
            var pascoa = CalcularPascoa(ano);

            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Carnaval", Data = pascoa.AddDays(-47), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Carnaval" },
                new Feriado { Nome = "Sexta-feira Santa", Data = pascoa.AddDays(-2), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Paixão de Cristo" },
                new Feriado { Nome = "Páscoa", Data = pascoa, Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Páscoa" },
                new Feriado { Nome = "Corpus Christi", Data = pascoa.AddDays(60), Tipo = TipoFeriado.Nacional, Recorrente = false, Descricao = "Corpus Christi" },
            });
        }

        context.Feriados.AddRange(feriados);
        context.SaveChanges();
    }

    // Algoritmo de Meeus/Jones/Butcher
    private static DateOnly CalcularPascoa(int ano)
    {
        int a = ano % 19;
        int b = ano / 100;
        int c = ano % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int mes = (h + l - 7 * m + 114) / 31;
        int dia = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateOnly(ano, mes, dia);
    }
}