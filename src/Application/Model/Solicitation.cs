using Infrastructure.Repository.Leads.Commands;

namespace Application.Model;

public record Solicitation
(
    int Id,
    Guid GuidSolicitation,
    byte Status,
    DateTime CreatedAt,
    Opportunite Opportunite,
    Vehicle Vehicle
)
{
    public static IReadOnlyList<Solicitation> CreateSolicitationsModel(List<SolicitationLead> value)
    {
        List<Solicitation> solicitations = [];

        foreach (SolicitationLead item in value)
        {
            solicitations.Add(ConverteToSolicitation(item));
        }

        return solicitations;
    }

    private static Solicitation ConverteToSolicitation(SolicitationLead item)
    {
        return new(
                        Id: item.Id,
                        GuidSolicitation: item.GuidSolicitation,
                        Status: item.Status,
                        CreatedAt: item.CreatedAt,
                        Opportunite: new
                        (
                            Id: item.OpportuniteLead.Id,
                            Status: item.OpportuniteLead.Status,
                            Type: item.OpportuniteLead.Type,
                            SaleDate: item.OpportuniteLead.SaleDate,
                            IssueDate: item.OpportuniteLead.IssueDate,
                            CanceledDate: item.OpportuniteLead.CanceledDate,
                            Insured: new
                            (
                                Id: item.OpportuniteLead.Insured.Id,
                                Name: item.OpportuniteLead.Insured.Name,
                                Cpf: item.OpportuniteLead.Insured.Cpf,
                                BirthDate: item.OpportuniteLead.Insured.BirthDate,
                                Gender: item.OpportuniteLead.Insured.Gender,
                                PhoneNumber: item.OpportuniteLead.Insured.PhoneNumber
                            )
                        ),
                        Vehicle: new
                        (
                            Id: item.Vehicle.Id,
                            Brand: item.Vehicle.Brand,
                            ModelYear: item.Vehicle.ModelYear,
                            Model: item.Vehicle.Model,
                            Plate: item.Vehicle.Plate
                        )
        );
    }

    public static Solicitation ConvertSolicitationLeadToSolicitation(SolicitationLead value)
    {
        return ConverteToSolicitation(value);
    }
}

public record Opportunite(
    int Id,
    byte Status,
    byte Type,
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
    string PhoneNumber
);

public record Vehicle(
    int Id,
    string Brand,
    string ModelYear,
    string Model,
    string Plate
);