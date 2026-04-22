using BrazilianHolidaysApi.Enums;
using BrazilianHolidaysApi.Interfaces;
using BrazilianHolidaysApi.Models;
using BrazilianHolidaysApi.Services;
using Moq;

namespace BrazilianHolidaysApi.Tests;

public class FeriadoServiceTests
{
    private readonly Mock<IFeriadoRepository> _repositoryMock;
    private readonly FeriadoService _service;

    public FeriadoServiceTests()
    {
        _repositoryMock = new Mock<IFeriadoRepository>();
        _service = new FeriadoService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ObterProximoFeriadoAsync_DeveRetornarFeriadoNacional()
    {
        // Arrange
        var feriadoEsperado = new Feriado
        {
            Nome = "Dia do Trabalho",
            Data = new DateOnly(DateTime.Today.Year, 5, 1),
            Tipo = TipoFeriado.Nacional,
            UF = null,
            Descricao = "Dia Internacional do Trabalho"
        };

        _repositoryMock
            .Setup(r => r.ObterProximoFeriadoAsync())
            .ReturnsAsync(feriadoEsperado);

        // Act
        var resultado = await _service.ObterProximoFeriadoAsync();

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(TipoFeriado.Nacional, resultado.Tipo);
        Assert.Equal("Dia do Trabalho", resultado.Nome);
    }

    [Fact]
    public async Task ObterProximoFeriadoAsync_QuandoNaoHouverFeriado_DeveRetornarNull()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.ObterProximoFeriadoAsync())
            .ReturnsAsync((Feriado?)null);

        // Act
        var resultado = await _service.ObterProximoFeriadoAsync();

        // Assert
        Assert.Null(resultado);
    }
}