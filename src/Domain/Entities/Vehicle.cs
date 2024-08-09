namespace Domain.Entities;

public record Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string LicensePlate { get; set; }
}