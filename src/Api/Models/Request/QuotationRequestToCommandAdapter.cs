using Application.UseCases.SolicitationLeads;
using Microsoft.AspNetCore.Builder;

namespace Api.Models.Request;

internal static class QuotationRequestToCommandAdapter
{
    public static CreateSolicitationLeadCommand ToCommand(this QuotationRequest request)
    {
        return new(
            InsuranceType: request.TipoLead,
            Insured: GetInsured(request.Segurado),
            Driver: GetDriver(request.Condutor),
            Vehicle: GetVehicle(request.Veiculo),
            Address: GetAddress(request.Endereco)
        );
    }

    private static Address GetAddress(Endereco endereco)
    {
        return new(
            Street: endereco.Rua,
            Number: endereco.Numero,
            Neighborhood: endereco.Bairro,
            City: endereco.Cidade,
            State: endereco.Estado,
            ZipCode: endereco.CEP,
            Complement: endereco.Complemento
        );
    }

    private static Vehicle GetVehicle(Veiculo veiculo)
    {
        return new(
            Brand: veiculo.Marca,
            ModelYear: veiculo.AnoModelo,
            Model: veiculo.Modelo,
            IsNew: veiculo.ZeroKm,
            Usage: veiculo.Utilizacao,
            OvernightZipCode: veiculo.CepPerNoite,
            ResidentialZipCode: veiculo.CepResidencia,
            Plate: veiculo.Placa,
            Chassi: veiculo.Chassi
        );
    }

    private static Driver GetDriver(Condutor condutor)
    {
        return new(
            Cpf: condutor.Cpf,
            Name: condutor.NomeCompleto,
            Gender: condutor.Genero,
            BirthDate: condutor.DataNascimento
        );
    }

    private static Insured GetInsured(Segurado segurado)
    {
        return new(
            Name: segurado.NomeCompleto,
            PersonType: segurado.TipoPessoa,
            Cpf: segurado.Cpf,
            BirthDate: segurado.DataNascimento,
            Gender: segurado.Genero,
            Email: segurado.Email,
            PhoneNumber: segurado.Telefone
        );
    }
}