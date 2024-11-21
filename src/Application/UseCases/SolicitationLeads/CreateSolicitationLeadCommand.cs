namespace Application.UseCases.SolicitationLeads;

public record CreateSolicitationLeadCommand
(
int InsuranceType,
Insured Insured,
Owner Owner,
DriverP PrimaryDriver,
Vehicle Vehicle
);


public record Insured
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

public record Owner
(
string Name,
string PersonType,
string Cpf,
string Gender,
string MaritalStatus,
string BirthDate
);

public record DriverP
(
string Cpf,
string Name,
string Gender,
string BirthDate,
string MaritalStatus,
string LivesWithInsured,
string RelationshipToInsured,
Driver17To25 Driver17To25
);

public record Driver17To25
(
    int Exists17To25
);

public record Vehicle
(
string IsNew,
string Usage,
VehicleUsageProfile UsageProfile,
string OvernightZipCode,
string CirculationZipCode,
string ResidentialZipCode,
string ResidentialGarage,
string WorkGarage,
int OvernightLocation,
VehicleDetails VehicleDetails
);

public record VehicleUsageProfile
(
int Usage
);

public record VehicleDetails
(
string? Brand,
string? ModelYear,
string? Model
);
