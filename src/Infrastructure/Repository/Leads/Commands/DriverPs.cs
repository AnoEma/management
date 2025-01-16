namespace Infrastructure.Repository.Leads.Commands;

public class DriverPs
{
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string BirthDate { get; set; }
    public string MaritalStatus { get; set; }
    public string LivesWithInsured { get; set; }
    public string RelationshipToInsured { get; set; }
    public virtual Driver17To25 Driver17To25 { get; set; }
}

public class Driver17To25
{
    public int Id { get; set; }
    public int Exists17To25 { get; set; }
}