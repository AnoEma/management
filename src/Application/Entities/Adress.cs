namespace Application.Entities;

public record Adress(
int Id,
string Street,
string Number,
string Neighborhood,
string City,
string State,
string PostalCode
);