namespace Infrastructure.Repository.Leads.Commands;

public enum OpportuniteStatus : byte
{
    Pending = 1,
    Sold = 2,
    Issued = 3,
    Canceled = 0,
    NotSold = 5
}