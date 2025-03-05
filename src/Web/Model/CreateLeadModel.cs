using Application.UseCases.SolicitationLeads;

namespace Web.Model;

public class CreateLeadModel
{
    public string Name { get; set; }
    public string DocumentCpf { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Marital { get; set; }
    public DateTime? BirthDate { get; set; } = null;
    public int Gender { get; set; }
    public Vehicle VehicleModel { get; set; } = new();
    public Address AddressModel { get; set; } = new();
    public Driver Driver { get; set; } = new();
    public int InsuranceType { get; set; }
    public int PersonType { get; set; }

    public static CreateSolicitationLeadCommand CreateCommand(CreateLeadModel model)
    {
        return new(
            InsuranceType: model.InsuranceType,
            Insured: new(
                Name: model.Name,
                Cpf: model.DocumentCpf,
                BirthDate: model.BirthDate.ToString(),
                Gender: model.Gender,
                Email: model.Email,
                PhoneNumber: model.PhoneNumber,
                PersonType: model.PersonType,
                Marital: model.Marital
            ),
            Driver: new(
                Cpf: model.Driver?.Cpf ?? model.DocumentCpf,
                Name: model.Driver?.Name ?? model.Name,
                Gender: model.Driver?.Gender ?? model.Gender,
                BirthDate: model.Driver?.BirthDate.ToString() ?? model.BirthDate.ToString(),
                Marital: model.Driver?.Marital ?? model.Marital
            ),
            Vehicle: new(
                 Brand: model.VehicleModel.Brand,
                 ModelYear: model.VehicleModel.ModelYear.ToString(),
                 Model: model.VehicleModel.Model,
                 IsNew: model.VehicleModel.IsNew,
                 Usage: model.VehicleModel.Usage.ToString(),
                 OvernightZipCode: model.AddressModel.ZipCode,
                 ResidentialZipCode: model.AddressModel.ZipCode,
                 Plate: model.VehicleModel.Plate,
                 Chassi: model.VehicleModel.Chassi
            ),
            Address: new(
                Street: model.AddressModel.Street,
                Number: model.AddressModel.Number,
                Neighborhood: model.AddressModel.Neighborhood,
                City: model.AddressModel.City,
                State: model.AddressModel.State,
                ZipCode: model.AddressModel.ZipCode,
                Complement: model.AddressModel.Complement
            )
        );
    }
}

public class Vehicle
{
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ModelYear { get; set; }
    public bool IsNew { get; set; }
    public int Usage { get; set; }
    public string Chassi { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Complement { get; set; }
    public int TypeResidential { get; set; }
}

public class Driver
{
    public string Cpf { get; set; }
    public string Name { get; set; }
    public int? Gender { get; set; }
    public DateTime? BirthDate { get; set; } = null;
    public int? Marital { get; set; }
}
