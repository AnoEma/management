namespace Infrastructure.Repository.Leads.Commands;

public class SolicitationLead
{
    public int Id { get; set; }
    public Guid GuidSolicitation { get; set; }
    public SolicitationStatus Status { get; set; }
    public Owner Owner { get; set; }
    public DriverP PrimaryDriver { get; set; }
    public Vehicle Vehicle { get; set; }
    public Comment Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public Transmission Transmission { get; set; }
    public OpportuniteLead OpportuniteLead { get; set; }
    public Address Address { get; set; }
}