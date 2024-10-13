namespace Infrastructure.HttpClients.Persons.HttpClients;

public record PersonResponse(
string cpf,
string nome,
string data_nascimento
);
