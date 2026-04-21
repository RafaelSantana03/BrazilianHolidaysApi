using BrazilianHolidays.Data.Context;

namespace BrazilianHolidays.Data.Seed;

public static class FeriadoSeed
{
    public static void Popular(AppDbContext context)
    {
        if (context.Feriados.Any())
            return;

        var anoAtual = DateTime.Today.Year;
        var anoFim = anoAtual + 5;

        var feriados = FeriadoNacionalSeed.Gerar(anoAtual, anoFim)
            .Concat(FeriadoEstadualSeed.Gerar(anoAtual, anoFim));

        context.Feriados.AddRange(feriados);
        context.SaveChanges();
    }
}