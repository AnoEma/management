namespace Infrastructure.Repository.Leads.Commands;

public class Transmission
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime InitialValidityDate { get; set; }
    public DateTime FinalValidityDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Insurer { get; set; }
    public int InsurerId { get; set; }
}