using Infrastructure.HttpClients.Addresses.HttpClients;

namespace Application.UseCases.Addresses.Models;

public record GetAddressResponse
(
string Street,
string Number,
string Neighborhood,
string City,
string State,
string StateUF,
string PostalCode,
string StreetType
)
{
    public static GetAddressResponse CreateAddressResponse(AddressResponse value)
    {
        return new(
            Street: value.Logradouro,
            Number: "",
            Neighborhood: value.Bairro,
            City: value.Municipio,
            State: value.Municipio,
            StateUF: value.Uf,
            PostalCode: value.Cep,
            StreetType: value.TipoLogradouro
        );
    }
}
