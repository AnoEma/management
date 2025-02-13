using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repository.Leads.Commands;

public class SolicitationLead
{
    public int Id { get; set; }
    public Guid GuidSolicitation { get; set; }
    public string QuotationId { get; set; }
    public byte Status { get; set; }
    public virtual Owner Owner { get; set; }
    public virtual Driver Driver { get; set; }
    public virtual Vehicle Vehicle { get; set; }
    public virtual Comment Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual Transmission Transmission { get; set; }
    public virtual OpportuniteLead OpportuniteLead { get; set; }
    public virtual Address Address { get; set; }
    public string QuotationToken { get; set; }
}