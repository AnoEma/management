namespace Infrastructure.HttpClients.Persons.HttpClients;

public record PersonRequest(
string CpfCnpj,
string EstruturaVendas,
string Source,
string TipoPessoa
)
{
    public PersonRequest GetPersonRequest()
    {
        return new PersonRequest(
            CpfCnpj: "",
            EstruturaVendas: "",
            Source: Source,
            TipoPessoa: TipoPessoa
        );
    }
};