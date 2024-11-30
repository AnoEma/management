using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Addresses.HttpClients;
using Infrastructure.HttpClients.Quotations.HttpClients;
using Infrastructure.Repository.Leads;
using Infrastructure.Repository.Leads.Commands;

namespace Application.UseCases.SolicitationLeads;

public class CreateSolicitationLeadCommandHandler(
    IQuotationApiHttpClient quotationApiHttpClient,
    ILeadCommandRepository commandRepository,
    IAddressApiHttpClient addressApiHttpClient
) : ICreateSolicitationLeadCommandHandler
{
    public async Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default)
    {
        QuotationRequest requestCommand = CreateRequestCommand(command);
        Result<QuotationResponse> response = await quotationApiHttpClient.CreatQuotationAsync(requestCommand, cancellationToken);

        Result<AddressResponse> address = await addressApiHttpClient.GetAddressAsync(command.Vehicle.OvernightZipCode, cancellationToken);
        Result<int> result = await commandRepository.SaveLeadAsync(CreateCommand(command, response.Value, address.Value), cancellationToken);


        if (response.IsFailure)
        {
            return Result.Failure("Erro");
        }

        return Result.Success(result);
    }

    private static SolicitationLead CreateCommand(CreateSolicitationLeadCommand command, QuotationResponse quotationResponse, AddressResponse addressResponse)
    {
        return new SolicitationLead
        {
            GuidSolicitation = Guid.NewGuid(),
            QuotationId = quotationResponse.QuotationId,
            Owner = new Infrastructure.Repository.Leads.Commands.Owner
            {
                BirthDate = command.Owner.BirthDate,
                Name = command.Owner.Name,
                Cpf = command.Owner.Cpf,
                Gender = command.Owner.Gender,
                MaritalStatus = command.Owner.MaritalStatus,
                PersonType = command.Owner.PersonType,
            },
            Vehicle = new Infrastructure.Repository.Leads.Commands.Vehicle
            {
                IsNew = command.Vehicle.IsNew,
                CirculationZipCode = command.Vehicle.CirculationZipCode,
                OvernightLocation = command.Vehicle.OvernightLocation,
                ResidentialGarage = command.Vehicle.ResidentialGarage,
                Usage = command.Vehicle.Usage,
                UsageProfile = new Infrastructure.Repository.Leads.Commands.VehicleUsageProfile
                {
                    Usage = command.Vehicle.UsageProfile.Usage
                },
                OvernightZipCode = command.Vehicle.OvernightZipCode,
                ResidentialZipCode = command.Vehicle.ResidentialZipCode,
                WorkGarage = command.Vehicle.WorkGarage,
                VehicleDetails = new Infrastructure.Repository.Leads.Commands.VehicleDetails
                {
                    Model = command.Vehicle.VehicleDetails.Model,
                    ModelYear = command.Vehicle.VehicleDetails.ModelYear,
                    Brand = command.Vehicle.VehicleDetails.Brand,
                }
            },
            PrimaryDriver = new Infrastructure.Repository.Leads.Commands.DriverP
            {
                Name = command.PrimaryDriver.Name,
                BirthDate = command.PrimaryDriver.BirthDate,
                Cpf = command.PrimaryDriver.Cpf,
                LivesWithInsured = command.PrimaryDriver.LivesWithInsured,
                Gender = command.PrimaryDriver.Gender,
                MaritalStatus = command.PrimaryDriver.MaritalStatus,
                RelationshipToInsured = command.PrimaryDriver.RelationshipToInsured,
                Driver17To25 = new Infrastructure.Repository.Leads.Commands.Driver17To25
                {
                    Exists17To25 = command.PrimaryDriver.Driver17To25.Exists17To25,
                }
            },
            OpportuniteLead = new OpportuniteLead
            {
                Status = OpportuniteStatus.Pending,
                Type = OpportuniteType.NewInsurance,
                Insured = new Infrastructure.Repository.Leads.Commands.Insured
                {
                    BirthDate = command.Insured.BirthDate,
                    Contact = command.Insured.Contact,
                    Cpf = command.Insured.Cpf,
                    Email = command.Insured.Email,
                    Gender = command.Insured.Gender,
                    Name = command.Insured.Name,
                    MaritalStatus = command.Insured.MaritalStatus,
                    PersonType = command.Insured.PersonType,
                    PhoneAreaCode = command.Insured.PhoneAreaCode,
                    PhoneNumber = command.Insured.PhoneNumber,
                    RelationshipToOwner = command.Insured.RelationshipToOwner,
                },
                CreateAt = DateTime.Now,
            },
            CreatedAt = DateTime.Now,
            Status = SolicitationStatus.Pending,
            QuotationToken = quotationResponse.QuotationToken,
            Address = new Address
            {
                City = addressResponse.Municipio,
                Number = "",
                Complement = "",
                Neighborhood = addressResponse.Bairro,
                State = addressResponse.Uf,
                Street = addressResponse.Logradouro,
                ZipCode = addressResponse.Cep
            }
        };
    }

    #region CreateRequestCommand
    private static QuotationRequest CreateRequestCommand(CreateSolicitationLeadCommand command)
    {
        return new(
            COTACAO: new Cotacao(
                TIPOSEG: command.InsuranceType,
                SEGURADO: GetSeguradora(command.Insured),
                PROPRIETARIO: GetOwner(command.Owner),
                CONDUTORP: GetDriverP(command.PrimaryDriver),
                VEICULO: GetVehicle(command.Vehicle)
            )
        );
    }

    private static Veiculo GetVehicle(Vehicle vehicle)
    {
        return new(
            CODCAR: vehicle.CodCar,
            MARCA: vehicle.Brand,
            ANOFABR: vehicle.ManufactureYear,
            ANOMODELO: vehicle.ModelYear,
            COMBUSTIVEL: vehicle.Fuel,
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
    #endregion
}
