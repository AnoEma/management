using Application.Model;

namespace Web.Model;

public class LeadsModel
{
    public int Id { get; set; }
    public int InsuranceType { get; set; }
    public string FullName { get; set; }
    public int Status { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Gender { get; set; }
    public string BirthDate { get; set; }
    public string DocumentCpf { get; set; }

    public VehicleDetails Vehicle { get; set; }
    public AddressDetails Address { get; set; }

    internal static IReadOnlyList<LeadsModel> CreateLeadsModel(IReadOnlyList<Solicitation> value)
    {
        List<LeadsModel> leadsModels = [];

        foreach (Solicitation item in value)
        {
            leadsModels.Add(new LeadsModel()
            {
                Id = item.Id,
                FullName = item.Opportunite.Insured.Name,
                DocumentCpf = item.Opportunite.Insured.Cpf,
                InsuranceType = item.Opportunite.Type,
                Status = item.Opportunite.Status,
                Vehicle = new VehicleDetails()
                {
                    Model = $"{item.Vehicle.Brand} {item.Vehicle.Model}",
                    Plate = item.Vehicle.Plate,
                    ModelYear = item.Vehicle.ModelYear
                }
            });
        }
        return leadsModels;
    }

    internal static LeadsModel CreateLeadsModel(Solicitation value)
    {
        return 
        new LeadsModel()
        {
            Id = value.Id,
            FullName = value.Opportunite.Insured.Name,
            InsuranceType = value.Opportunite.Type,
            Status = value.Opportunite.Status,
            Email = value.Opportunite.Insured.Email,
            Phone = value.Opportunite.Insured.PhoneNumber,
            Gender = value.Opportunite.Insured.Gender,
            BirthDate = value.Opportunite.Insured.BirthDate,
            Vehicle = new VehicleDetails()
            {
              Model = $"{value.Vehicle.Brand} {value.Vehicle.Model}",
              Plate = value.Vehicle.Plate,
              ModelYear = value.Vehicle.ModelYear
            },
            Address = new AddressDetails()
            {
                Streets = value.Address.Street,
                Neighborhoods = value.Address.Neighborhood,
                States = value.Address.State,
                ZipCodes = value.Address.ZipCode,
                Numbers = value.Address.Number
            }
        };
    }
}

public class VehicleDetails
{
    public string Model { get; set; }
    public string Plate { get; set; }
    public string ModelYear { get; set; }
}

public class AddressDetails
{
    public string Streets { get; set; }
    public string Neighborhoods { get; set; }
    public string States { get; set; }
    public string ZipCodes { get; set; }
    public string Numbers { get; set; }
}
