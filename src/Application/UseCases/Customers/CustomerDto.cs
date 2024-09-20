using Application.Entities;

namespace Application.UseCases.Customers;

public record CustomerDto(
int Id,
string Address,
Person Person,
Vehicle Vehicle
);

public record Vehicle(
int Id,
string Brand,
string Model,
int YearModel,
int YearManufacture,
string LicensePlate
);