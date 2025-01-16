using Application.Model;

namespace Web.Model;

public class LeadsModel
{
    public int Id { get; set; }
    public int InsuranceType { get; set; }
    public string FullName { get; set; }
    public int Status { get; set; }
    public VehicleDetails Vehicle { get; set; }

    internal static IReadOnlyList<LeadsModel> CreateLeadsModel(IReadOnlyList<Solicitation> value)
    {
        List<LeadsModel> leadsModels = [];

        foreach (Solicitation item in value)
        {
            leadsModels.Add(new()
            {
                Id = item.Id,
                FullName = item.Opportunite.Insured.Name,
                InsuranceType = item.Opportunite.Type,
                Status = item.Opportunite.Status,
                Vehicle = new()
                {
                    Model = $"{item.Vehicle.Brand} {item.Vehicle.Model}",
                    Plate = "XXX-CCC",
                    ModelYear = item.Vehicle.ModelYear
                }
            });
        }
        return leadsModels;
    }
}

public class VehicleDetails
{
    public string Model { get; set; }
    public string Plate { get; set; }
    public string ModelYear { get; set; }
}
