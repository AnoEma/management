namespace Application.Model;

public enum OpportuniteStatus: byte
{
    Pending = 1,
    Attended = 2,
    Sold = 3,
    Issued = 4,
    Canceled = 0,
    NotSold = 5
}