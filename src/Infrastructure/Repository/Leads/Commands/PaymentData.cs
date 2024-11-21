namespace Infrastructure.Repository.Leads.Commands;

public class PaymentData
{
    public int Id { get; set; }
    public PaymentType PaymentType { get; set; }
    public AccountPayment AccountPayment { get; set; }
    public CreditPayment CreditPayment { get; set; }
}

public class AccountPayment
{
    public int Id { get; set; }
}
public class CreditPayment
{
    public int Id { get; set; }
}