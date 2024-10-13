using CSharpFunctionalExtensions;
using FluentAssertions;
using Infrastructure.HttpClients.Persons.HttpClients;
using NSubstitute;
using System.Net;

namespace Infrastructure.Tests.HttpClients.Persons;

public class PersonApiHttpClientTests(PersonApiContentRespoonseFixture _fixture, string baseAddress = "https://dummy.api.net")
    : IClassFixture<PersonApiContentRespoonseFixture>
{
    [Fact]
    public async Task GetPerson_ReturnsSuccess_WhenHttpResponseIsSuccessful()
    {
        //Arrange
        PersonRequest request = new(
            CpfCnpj: "123456789",
            EstruturaVendas: "1",
            Source: "test",
            TipoPessoa: "1"
        );
        string query = $"?cpf_cnpj={request.CpfCnpj}&estrutura_vendas={request.EstruturaVendas}&source={request.Source}&tipo_pessoa={request.TipoPessoa}";
        CancellationToken cancellation = new();

        var httpClientHandler = Substitute.For<HttpMessageHandler>();
        var client = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri(baseAddress)
        };

        httpClientHandler
            .SetupRequest(HttpMethod.Get, $"{baseAddress}/person/v1/search{query}")
            .ReturnsResponse(HttpStatusCode.OK, _fixture.PersonResponse);

        PersonApiHttpClient personApiHttp = new(client);

        //Act
        var result = await personApiHttp.GetPerson(request, cancellation);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPerson_ReturnsFailure_WhenHttpResponseIsNotSuccessful()
    {
        //Arrange
        PersonRequest request = new(
            CpfCnpj: "123456789",
            EstruturaVendas: "1",
            Source: "test",
            TipoPessoa: "1"
        );
        string query = $"?cpf_cnpj={request.CpfCnpj}&estrutura_vendas={request.EstruturaVendas}&source={request.Source}&tipo_pessoa={request.TipoPessoa}";
        CancellationToken cancellation = new();

        var httpClientHandler = Substitute.For<HttpMessageHandler>();
        var client = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri(baseAddress)
        };

        httpClientHandler
            .SetupRequest(HttpMethod.Get, $"{baseAddress}/person/v1/search{query}")
            .ReturnsResponse(HttpStatusCode.InternalServerError, Result.Failure<PersonResponse>("Erro"));

        PersonApiHttpClient personApiHttp = new(client);

        //Act
        var result = await personApiHttp.GetPerson(request, cancellation);

        //Assert
        result.IsFailure.Should().BeTrue();
    }
}
