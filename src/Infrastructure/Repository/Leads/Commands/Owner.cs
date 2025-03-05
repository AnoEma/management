namespace Infrastructure.Repository.Leads.Commands;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PersonType { get; set; }
    public string Cpf { get; set; }
    public int Gender { get; set; }
    public string BirthDate { get; set; }
    public int Marital { get; set; }
}