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
int Gender,
string Email,
string PhoneNumber,
int Marital
);


public record Driver
(
string Cpf,
string Name,
int Gender,
string BirthDate,
int Marital
);

public record Vehicle
(
string Brand,
string ModelYear,
string Model,
bool IsNew,
string Usage,
string OvernightZipCode,
string ResidentialZipCode,
string Plate,
string Chassi
);

public record Address
(
string? Street,
string? Number,
string? Neighborhood,
string? City,
string? State,
string? ZipCode,
string? Complement
);
