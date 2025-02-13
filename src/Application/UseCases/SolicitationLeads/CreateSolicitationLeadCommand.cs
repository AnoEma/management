namespace Application.UseCases.SolicitationLeads;

public record CreateSolicitationLeadCommand
(
int InsuranceType,
Insured Insured,
Driver Driver,
Vehicle Vehicle,
Address Address
);


public record Insured
(
string Name,
int PersonType,
string Cpf,
string BirthDate,
string Gender,
string Email,
string PhoneNumber
);


public record Driver
(
string Cpf,
string Name,
string Gender,
string BirthDate
);

public record Vehicle
(
string Brand,
string ModelYear,
string Model,
string IsNew,
string Usage,
string OvernightZipCode,
string ResidentialZipCode,
string Plate,
string Chassi
);

public record Address
(
string Street,
string Number,
string Neighborhood,
string City,
string State,
string ZipCode,
string? Complement
);
