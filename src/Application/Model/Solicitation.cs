using Infrastructure.Repository.Leads.Commands;

namespace Application.Model;

public record Solicitation
(
)
{
    public static IEnumerable<Solicitation> CreateSolicitationModel(List<SolicitationLead> value)
    {
        throw new NotImplementedException();
    }
}
