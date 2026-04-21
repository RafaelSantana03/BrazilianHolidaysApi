using BrazilianHolidaysApi.Enums;
using BrazilianHolidaysApi.Models;

namespace BrazilianHolidaysApi.Data.Seed;

public static class FeriadoEstadualSeed
{
    public static IEnumerable<Feriado> Gerar(int anoInicio, int anoFim)
    {
        var feriados = new List<Feriado>();

        for (int ano = anoInicio; ano <= anoFim; ano++)
        {
            var pascoa = PascoaHelper.Calcular(ano);

            // Acre - AC
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Dia do Evangélico", Data = new DateOnly(ano, 1, 23), Tipo = TipoFeriado.Estadual, UF = "AC", Recorrente = true },
                new Feriado { Nome = "Aniversário do Acre", Data = new DateOnly(ano, 6, 15), Tipo = TipoFeriado.Estadual, UF = "AC", Recorrente = true },
                new Feriado { Nome = "Amazônia", Data = new DateOnly(ano, 9, 5), Tipo = TipoFeriado.Estadual, UF = "AC", Recorrente = true },
                new Feriado { Nome = "Tratado de Petrópolis", Data = new DateOnly(ano, 11, 17), Tipo = TipoFeriado.Estadual, UF = "AC", Recorrente = true },
            });

            // Alagoas - AL
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "São João", Data = new DateOnly(ano, 6, 24), Tipo = TipoFeriado.Estadual, UF = "AL", Recorrente = true },
                new Feriado { Nome = "São Pedro", Data = new DateOnly(ano, 6, 29), Tipo = TipoFeriado.Estadual, UF = "AL", Recorrente = true },
                new Feriado { Nome = "Emancipação Política de Alagoas", Data = new DateOnly(ano, 9, 16), Tipo = TipoFeriado.Estadual, UF = "AL", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora dos Prazeres", Data = new DateOnly(ano, 11, 8), Tipo = TipoFeriado.Estadual, UF = "AL", Recorrente = true },
            });

            // Amazonas - AM
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Elevação do Amazonas à Categoria de Província", Data = new DateOnly(ano, 9, 5), Tipo = TipoFeriado.Estadual, UF = "AM", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Conceição", Data = new DateOnly(ano, 12, 8), Tipo = TipoFeriado.Estadual, UF = "AM", Recorrente = true },
            });

            // Amapá - AP
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "São José", Data = new DateOnly(ano, 3, 19), Tipo = TipoFeriado.Estadual, UF = "AP", Recorrente = true },
                new Feriado { Nome = "Aniversário do Amapá", Data = new DateOnly(ano, 9, 13), Tipo = TipoFeriado.Estadual, UF = "AP", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Conceição", Data = new DateOnly(ano, 12, 8), Tipo = TipoFeriado.Estadual, UF = "AP", Recorrente = true },
            });

            // Bahia - BA
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Independência da Bahia", Data = new DateOnly(ano, 7, 2), Tipo = TipoFeriado.Estadual, UF = "BA", Recorrente = true },
            });

            // Ceará - CE
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "São José", Data = new DateOnly(ano, 3, 19), Tipo = TipoFeriado.Estadual, UF = "CE", Recorrente = true },
                new Feriado { Nome = "Abolição da Escravidão no Ceará", Data = new DateOnly(ano, 3, 25), Tipo = TipoFeriado.Estadual, UF = "CE", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Assunção", Data = new DateOnly(ano, 8, 15), Tipo = TipoFeriado.Estadual, UF = "CE", Recorrente = true },
            });

            // Distrito Federal - DF
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Fundação de Brasília", Data = new DateOnly(ano, 4, 21), Tipo = TipoFeriado.Estadual, UF = "DF", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora Aparecida", Data = new DateOnly(ano, 10, 12), Tipo = TipoFeriado.Estadual, UF = "DF", Recorrente = true },
            });

            // Espírito Santo - ES
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Nossa Senhora da Penha", Data = new DateOnly(ano, 4, 13), Tipo = TipoFeriado.Estadual, UF = "ES", Recorrente = true, Descricao = "Padroeira do Espírito Santo" },
            });

            // Goiás - GO
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Fundação da Cidade de Goiás", Data = new DateOnly(ano, 7, 26), Tipo = TipoFeriado.Estadual, UF = "GO", Recorrente = true },
                new Feriado { Nome = "Aniversário de Goiânia", Data = new DateOnly(ano, 10, 24), Tipo = TipoFeriado.Estadual, UF = "GO", Recorrente = true },
            });

            // Maranhão - MA
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Adesão do Maranhão à Independência do Brasil", Data = new DateOnly(ano, 7, 28), Tipo = TipoFeriado.Estadual, UF = "MA", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Vitória", Data = new DateOnly(ano, 9, 8), Tipo = TipoFeriado.Estadual, UF = "MA", Recorrente = true },
            });

            // Minas Gerais - MG
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Execução de Tiradentes", Data = new DateOnly(ano, 4, 21), Tipo = TipoFeriado.Estadual, UF = "MG", Recorrente = true },
            });

            // Mato Grosso do Sul - MS
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Criação do Estado", Data = new DateOnly(ano, 10, 11), Tipo = TipoFeriado.Estadual, UF = "MS", Recorrente = true },
            });

            // Mato Grosso - MT
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Consciência Negra", Data = new DateOnly(ano, 11, 20), Tipo = TipoFeriado.Estadual, UF = "MT", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Conceição", Data = new DateOnly(ano, 12, 8), Tipo = TipoFeriado.Estadual, UF = "MT", Recorrente = true },
            });

            // Pará - PA
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Adesão do Pará à Independência do Brasil", Data = new DateOnly(ano, 8, 15), Tipo = TipoFeriado.Estadual, UF = "PA", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora de Nazaré", Data = pascoa.AddDays(166), Tipo = TipoFeriado.Estadual, UF = "PA", Recorrente = false, Descricao = "Segundo domingo de outubro" },
            });

            // Paraíba - PB
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Homenagem a João Pessoa", Data = new DateOnly(ano, 7, 26), Tipo = TipoFeriado.Estadual, UF = "PB", Recorrente = true },
            });

            // Pernambuco - PE
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Revolução Pernambucana", Data = new DateOnly(ano, 3, 6), Tipo = TipoFeriado.Estadual, UF = "PE", Recorrente = true },
                new Feriado { Nome = "São João", Data = new DateOnly(ano, 6, 24), Tipo = TipoFeriado.Estadual, UF = "PE", Recorrente = true },
            });

            // Piauí - PI
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Dia do Piauí", Data = new DateOnly(ano, 10, 19), Tipo = TipoFeriado.Estadual, UF = "PI", Recorrente = true },
            });

            // Paraná - PR
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Emancipação do Paraná", Data = new DateOnly(ano, 12, 19), Tipo = TipoFeriado.Estadual, UF = "PR", Recorrente = true },
            });

            // Rio de Janeiro - RJ
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "São Jorge", Data = new DateOnly(ano, 4, 23), Tipo = TipoFeriado.Estadual, UF = "RJ", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Penha", Data = new DateOnly(ano, 10, 12), Tipo = TipoFeriado.Estadual, UF = "RJ", Recorrente = true },
                new Feriado { Nome = "Aniversário do Rio de Janeiro", Data = new DateOnly(ano, 11, 20), Tipo = TipoFeriado.Estadual, UF = "RJ", Recorrente = true },
            });

            // Rio Grande do Norte - RN
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Mártires de Cunhaú e Uruaçu", Data = new DateOnly(ano, 10, 3), Tipo = TipoFeriado.Estadual, UF = "RN", Recorrente = true },
            });

            // Rondônia - RO
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Dia do Evangélico", Data = new DateOnly(ano, 6, 18), Tipo = TipoFeriado.Estadual, UF = "RO", Recorrente = true },
                new Feriado { Nome = "Aniversário de Rondônia", Data = new DateOnly(ano, 1, 4), Tipo = TipoFeriado.Estadual, UF = "RO", Recorrente = true },
            });

            // Roraima - RR
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Aniversário de Roraima", Data = new DateOnly(ano, 10, 5), Tipo = TipoFeriado.Estadual, UF = "RR", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Consolata", Data = new DateOnly(ano, 7, 26), Tipo = TipoFeriado.Estadual, UF = "RR", Recorrente = true },
            });

            // Rio Grande do Sul - RS
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Revolução Farroupilha", Data = new DateOnly(ano, 9, 20), Tipo = TipoFeriado.Estadual, UF = "RS", Recorrente = true },
            });

            // Santa Catarina - SC
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Aniversário de Santa Catarina", Data = new DateOnly(ano, 8, 11), Tipo = TipoFeriado.Estadual, UF = "SC", Recorrente = true },
                new Feriado { Nome = "Nossa Senhora da Conceição", Data = new DateOnly(ano, 12, 8), Tipo = TipoFeriado.Estadual, UF = "SC", Recorrente = true },
            });

            // Sergipe - SE
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Nossa Senhora da Conceição", Data = new DateOnly(ano, 12, 8), Tipo = TipoFeriado.Estadual, UF = "SE", Recorrente = true },
                new Feriado { Nome = "Emancipação Política de Sergipe", Data = new DateOnly(ano, 7, 8), Tipo = TipoFeriado.Estadual, UF = "SE", Recorrente = true },
            });

            // São Paulo - SP
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Aniversário de São Paulo", Data = new DateOnly(ano, 1, 25), Tipo = TipoFeriado.Estadual, UF = "SP", Recorrente = true },
                new Feriado { Nome = "Revolução Constitucionalista", Data = new DateOnly(ano, 7, 9), Tipo = TipoFeriado.Estadual, UF = "SP", Recorrente = true },
            });

            // Tocantins - TO
            feriados.AddRange(new[]
            {
                new Feriado { Nome = "Nossa Senhora da Natividade", Data = new DateOnly(ano, 9, 8), Tipo = TipoFeriado.Estadual, UF = "TO", Recorrente = true },
                new Feriado { Nome = "Criação do Estado do Tocantins", Data = new DateOnly(ano, 10, 5), Tipo = TipoFeriado.Estadual, UF = "TO", Recorrente = true },
            });
        }

        return feriados;
    }
}