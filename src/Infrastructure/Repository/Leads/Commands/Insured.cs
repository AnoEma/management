namespace Infrastructure.Repository.Leads.Commands;

public class Insured
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PersonType { get; set; }
    public string Cpf { get; set; }
    public string BirthDate { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string Email { get; set; }
    public string PhoneAreaCode { get; set; }
    public string PhoneNumber { get; set; }
    public string RelationshipToOwner { get; set; }
    public string Contact { get; set; }
}