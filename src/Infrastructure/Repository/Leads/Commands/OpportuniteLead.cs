namespace Infrastructure.Repository.Leads.Commands;

public record OpportuniteLead
{
    public int Id { get; set; }
    public byte Status { get; set; }
    public byte Type { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime StartLead { get; set; }
    public int InsuredId { get; set; }
    public DateTime? SaleDate { get; set; } = null;
    public DateTime? IssueDate { get; set; } = null;
    public DateTime? CanceledDate { get; set; } = null;
    public virtual Insured Insured { get; set; }

    //public void SoldLead()
    //{
    //    SaleDate = DateTime.Now;
    //    Status = (byte)OpportuniteStatus.Sold;
    //}

    //public void IssuedLead()
    //{
    //    IssueDate = DateTime.Now;
    //    Status = (byte)OpportuniteStatus.Issued;
    //}

    //public void CanceledLead()
    //{
    //    CanceledDate = DateTime.Now;
    //    Status = (byte)OpportuniteStatus.Canceled;
    //}

    //public void AttendedLead()
    //{
    //    StartLead = DateTime.Now;
    //    Status = (byte)OpportuniteStatus.Attended;
    //}
}