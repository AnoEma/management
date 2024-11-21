namespace Infrastructure.Repository.Leads.Commands;

public class Vehicle
{
    public int Id { get; set; }
    public string IsNew { get; set; }
    public string Usage { get; set; }
    public VehicleUsageProfile UsageProfile { get; set; }
    public string OvernightZipCode { get; set; }
    public string CirculationZipCode { get; set; }
    public string ResidentialZipCode { get; set; }
    public string ResidentialGarage { get; set; }
    public string WorkGarage { get; set; }
    public int OvernightLocation { get; set; }
    public VehicleDetails VehicleDetails { get; set; }
}