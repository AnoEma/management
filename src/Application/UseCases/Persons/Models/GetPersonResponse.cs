using Infrastructure.HttpClients.Persons.HttpClients;

namespace Application.UseCases.Persons.Models;

public record GetPersonResponse(
string Name,
string Cpf,
string BirthDate
)
{
    public static GetPersonResponse CreatePersonResponse(PersonResponse apiResponse)
    {
        return new(
            Name: apiResponse.nome,
            Cpf: apiResponse.cpf,
            BirthDate: apiResponse.data_nascimento
        );
    }
};
