namespace Infrastructure.Repository.Leads.Commands;

public class Insured
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PersonType { get; set; }
    public string Cpf { get; set; }
    public string BirthDate { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}