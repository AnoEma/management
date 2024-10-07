using Application.Entities;

namespace Application.UseCases.Customers;

public record Customer(
int Id,
string Address,
Person Person
);