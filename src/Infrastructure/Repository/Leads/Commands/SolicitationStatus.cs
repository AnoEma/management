namespace Infrastructure.Repository.Leads.Commands;

public enum SolicitationStatus : byte
{
    Pending = 1,
    Edited = 2,
    Sold = 3,
    Issued = 4,
    Canceled = 0
}