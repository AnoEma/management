using Infrastructure.Repository.Leads.Commands;

namespace Application.Model;

public record Solicitation
(
    int Id,
    Guid GuidSolicitation,
    int Status,
    DateTime CreatedAt,
    Opportunite Opportunite
)
{
    public static IEnumerable<Solicitation> CreateSolicitationModel(List<SolicitationLead> value)
    {
        throw new NotImplementedException();
    }
}

public record Opportunite(
    int Id,
    int Status,
    int Type,
    DateTime? SaleDate,
    DateTime? IssueDate, 
    DateTime? CanceledDate,
    InsuredLead Insured
);

public record InsuredLead(
    int Id,
    string Name,
    string Cpf,
    string BirthDate,
    string Gender,
    string MaritalStatus,
    string PhoneAreaCode,
    string PhoneNumber
);