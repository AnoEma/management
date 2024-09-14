using Application.Entities;

namespace Application.UseCases.Customers;

public record CustomerDto(
int Id,
string Address,
Person Person
);
