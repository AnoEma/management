using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Quotations.HttpClients;

namespace Application.UseCases.SolicitationLead;

public class CreateSolicitationLeadCommandHandler(IQuotationApiHttpClient quotationApiHttpClient) : ICreateSolicitationLeadCommandHandler
{
    public async Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default)
    {
        QuotationRequest requestCommand = CreateRequestCommand(command);
        Result result = await quotationApiHttpClient.CreatQuotationAsync(requestCommand, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure("Erro");
        }

        return result;
    }

    private static QuotationRequest CreateRequestCommand(CreateSolicitationLeadCommand command)
    {
        return new(
            TIPOSEG: command.InsuranceType,
            SEGURADO: GetSeguradora(command.Insured),
            PROPRIETARIO: GetOwner(command.Owner),
            CONDUTORP: GetDriverP(command.PrimaryDriver),
            VEICULO: GetVehicle(command.Vehicle)
        );
    }

    private static Veiculo GetVehicle(Vehicle vehicle)
    {
        return new(
            ZEROKM: vehicle.IsNew,
            UTILIZACAO: vehicle.Usage,
            PERFILUSOVEIC: new PerfilUsoVeic(vehicle.UsageProfile.Usage),
            CEPPERNOITE: vehicle.OvernightZipCode,
            CEPCIRC: vehicle.CirculationZipCode,
            CEPRESID: vehicle.ResidentialZipCode,
            GARAGRESID: vehicle.ResidentialGarage,
            GARAGTRAB: vehicle.WorkGarage,
            LOCALPERNOITE: vehicle.OvernightLocation
        );
    }

    private static CondutorP GetDriverP(DriverP primaryDriver)
    {
        return new(
            CPFCOND: primaryDriver.Cpf,
            NOMECOND: primaryDriver.Name,
            SEXOCOND: primaryDriver.Gender,
            NASCCOND: primaryDriver.BirthDate,
            ESTCIVILCOND: primaryDriver.MaritalStatus,
            RESIDEEM: primaryDriver.LivesWithInsured,
            RELASEG: primaryDriver.RelationshipToInsured,
            CONDS17A25: new(primaryDriver.Driver17To25.Exists17To25) 
        );
    }

    private static Proprietario GetOwner(Owner owner)
    {
        return new Proprietario(
            NOMEPROP: owner.Name,
            PESSOAPROP: owner.PersonType,
            CGCPROP: owner.Cpf,
            SEXOPROP: owner.Gender,
            ESTCIVILPROP: owner.MaritalStatus,
            NASCPROP: owner.BirthDate
        );
    }

    private static Segurado GetSeguradora(Insured insured)
    {
        return new(
            NOMESEG: insured.Name,
            PESSOASEG: insured.PersonType,
            CGCSEG: insured.Cpf,
            NASCSEG: insured.BirthDate,
            SEXOSEG: insured.Gender,
            ESTCIVILSEG: insured.Gender,
            EMAILPES: insured.Email,
            DDDCEL: insured.PhoneAreaCode,
            CEL: insured.PhoneNumber,
            RELAPROPR: insured.RelationshipToOwner,
            CONTATO: insured.Contact
        );
    }
}
