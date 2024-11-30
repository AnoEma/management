using Application.UseCases.SolicitationLeads;

namespace Api.Models.Request;

internal static class QuotationRequestToCommandAdapter
{
    public static CreateSolicitationLeadCommand ToCommand(this QuotationRequest request)
    {
        return new(
            InsuranceType: request.TIPOSEG,
            Insured: GetInsured(request.SEGURADO),
            Owner: GetOwner(request.PROPRIETARIO),
            PrimaryDriver: GetDriver(request.CONDUTORP),
            Vehicle: GetVehicle(request.VEICULO)
        );
    }

    private static Vehicle GetVehicle(Veiculo veiculo)
    {
        return new(
            CodCar: veiculo.CODCAR,
            Brand: veiculo.MARCA,
            ManufactureYear: veiculo.ANOFABR,
            ModelYear: veiculo.ANOMODELO,
            Fuel: veiculo.COMBUSTIVEL,
            IsNew: veiculo.ZEROKM,
            Usage: veiculo.UTILIZACAO,
            UsageProfile: new VehicleUsageProfile(veiculo.PERFILUSOVEIC.USO),
            OvernightZipCode: veiculo.CEPPERNOITE,
            CirculationZipCode: veiculo.CEPCIRC,
            ResidentialZipCode: veiculo.CEPRESID,
            ResidentialGarage: veiculo.GARAGRESID,
            WorkGarage: veiculo.GARAGTRAB,
            OvernightLocation: veiculo.LOCALPERNOITE,
            VehicleDetails: GetVehicleDetails(veiculo?.Dadosveiculo)
        );
    }

    private static VehicleDetails GetVehicleDetails(DadosVeiculo? dadosveiculo)
    {
        return new VehicleDetails(
            Brand: dadosveiculo?.MarcaVeiculo,
            ModelYear: dadosveiculo?.AnoModelo,
            Model: dadosveiculo?.ModeloVeiculo
        );
    }

    private static DriverP GetDriver(CondutorP condutorP)
    {
        return new DriverP(
            Cpf: condutorP.CPFCOND,
            Name: condutorP.NOMECOND,
            Gender: condutorP.SEXOCOND,
            BirthDate: condutorP.NASCCOND,
            MaritalStatus: condutorP.ESTCIVILCOND,
            LivesWithInsured: condutorP.RESIDEEM,
            RelationshipToInsured: condutorP.RELASEG,
            Driver17To25: new(condutorP.CONDS17A25.EXISTE17A25)
        );
    }

    private static Owner GetOwner(Proprietario proprietario)
    {
        return new(
            Name: proprietario.NOMEPROP,
            PersonType: proprietario.PESSOAPROP,
            Cpf: proprietario.CGCPROP,
            Gender: proprietario.SEXOPROP,
            MaritalStatus: proprietario.ESTCIVILPROP,
            BirthDate: proprietario.NASCPROP
        );
    }

    private static Insured GetInsured(Segurado segurado)
    {
        return new(
            Name: segurado.NOMESEG,
            PersonType: segurado.PESSOASEG,
            Cpf: segurado.CGCSEG,
            BirthDate: segurado.NASCSEG,
            Gender: segurado.SEXOSEG,
            MaritalStatus: segurado.ESTCIVILSEG,
            Email: segurado.EMAILPES,
            PhoneAreaCode: segurado.DDDCEL,
            PhoneNumber: segurado.CEL,
            RelationshipToOwner: segurado.RELAPROPR,
            Contact: segurado.CONTATO
        );
    }
}