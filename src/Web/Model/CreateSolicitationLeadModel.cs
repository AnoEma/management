
using Application.UseCases.SolicitationLeads;

namespace Web.Model;

public record CreateSolicitationLeadModel
(
int InsuranceType,
InsuredModel Insured,
OwnerModel Owner,
DriverPModel PrimaryDriver,
VehicleModel Vehicle
)
{
    internal static CreateSolicitationLeadCommand CreateCommand(CreateSolicitationLeadModel model) => new(
            InsuranceType: model.InsuranceType,
            Insured: new(
                model.Insured.Name,
                model.Insured.PersonType,
                model.Insured.Cpf,
                model.Insured.BirthDate,
                model.Insured.Gender,
                model.Insured.MaritalStatus,
                model.Insured.Email,
                model.Insured.PhoneAreaCode,
                model.Insured.PhoneNumber,
                model.Insured.RelationshipToOwner,
                model.Insured.Contact
                ),
            Owner: new(
                model.Owner.Name,
                model.Owner.PersonType,
                model.Owner.Cpf,
                model.Owner.Gender,
                model.Owner.MaritalStatus,
                model.Owner.BirthDate
                ),
             PrimaryDriver: new(
                model.PrimaryDriver.Name,
                model.PrimaryDriver.Cpf,
                model.PrimaryDriver.Gender,
                model.PrimaryDriver.BirthDate,
                model.PrimaryDriver.MaritalStatus,
                model.PrimaryDriver.LivesWithInsured,
                model.PrimaryDriver.RelationshipToInsured,
                Driver17To25: new(
                    Exists17To25: 0
                    )
                ),
             Vehicle: new(
                 CodCar: model.Vehicle.CodCar,
                 Brand: model.Vehicle.Brand,
                 ManufactureYear: model.Vehicle.ManufactureYear,
                 ModelYear: model.Vehicle.ModelYear,
                 Model: model.Vehicle.Model,
                 Fuel: model.Vehicle.Fuel,
                 IsNew: model.Vehicle.IsNew,
                 Usage: model.Vehicle.Usage,
                 UsageProfile: new(
                     model.Vehicle.UsageProfile.Usage
                     ),
                 OvernightZipCode: model.Vehicle.OvernightZipCode,
                 CirculationZipCode: model.Vehicle.CirculationZipCode,
                 ResidentialZipCode: model.Vehicle.ResidentialZipCode,
                 ResidentialGarage: model.Vehicle.ResidentialGarage,
                 WorkGarage: model.Vehicle.WorkGarage,
                 OvernightLocation: model.Vehicle.OvernightLocation
                 )
            );
}

public record InsuredModel
(
string Name,
string PersonType,
string Cpf,
string BirthDate,
string Gender,
string MaritalStatus,
string Email,
string PhoneAreaCode,
string PhoneNumber,
string RelationshipToOwner,
string Contact
);

public record OwnerModel
(
string Name,
string PersonType,
string Cpf,
string Gender,
string MaritalStatus,
string BirthDate
);

public record DriverPModel
(
string Cpf,
string Name,
string Gender,
string BirthDate,
string MaritalStatus,
string LivesWithInsured,
string RelationshipToInsured
);

public record VehicleModel
(
int CodCar,
string Brand,
string ManufactureYear,
string ModelYear,
string Model,
string Fuel,
string IsNew,
string Usage,
VehicleUsageProfileModel UsageProfile,
string OvernightZipCode,
string CirculationZipCode,
string ResidentialZipCode,
string ResidentialGarage,
string WorkGarage,
int OvernightLocation
);

public record VehicleUsageProfileModel
(
int Usage
);
