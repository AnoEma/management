namespace Infrastructure.Repository.Leads.Commands;

public class Vehicle
{
    public int Id { get; set; }
    public bool IsNew { get; set; }
    public string Brand { get; set; }
    public string ModelYear { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public string Usage { get; set; }
    public string OvernightZipCode { get; set; }
    public string ResidentialZipCode { get; set; }
    public string Chassi { get; set; }
}