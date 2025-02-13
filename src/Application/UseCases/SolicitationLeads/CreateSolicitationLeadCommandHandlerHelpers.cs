using Application.Model;
using Application.UseCases.SolicitationLeads;
using Infrastructure.Repository.Leads.Commands;

internal static class CreateSolicitationLeadCommandHandlerHelpers
{
    internal static SolicitationLead CreateCommand(CreateSolicitationLeadCommand command)
    {
        return new SolicitationLead
        {
            GuidSolicitation = Guid.NewGuid(),
            QuotationId = Guid.NewGuid().ToString(),
            Owner = new Infrastructure.Repository.Leads.Commands.Owner
            {
                BirthDate = command.Insured.BirthDate,
                Name = command.Insured.Name,
                Cpf = command.Insured.Cpf,
                Gender = command.Insured.Gender,
                PersonType = command.Insured.PersonType,
            },
            Vehicle = new Infrastructure.Repository.Leads.Commands.Vehicle
            {
                IsNew = command.Vehicle.IsNew,
                Usage = command.Vehicle.Usage,
                OvernightZipCode = command.Vehicle.OvernightZipCode,
                ResidentialZipCode = command.Vehicle.ResidentialZipCode,
                Model = command.Vehicle.Model,
                ModelYear = command.Vehicle.ModelYear,
                Brand = command.Vehicle.Brand,
                Plate = command.Vehicle.Plate,
                Chassi = command.Vehicle.Chassi
            },
            Driver = new Infrastructure.Repository.Leads.Commands.Driver
            {
                Name = command.Driver.Name,
                BirthDate = command.Driver.BirthDate,
                Cpf = command.Driver.Cpf,
                Gender = command.Driver.Gender
            },
            OpportuniteLead = new OpportuniteLead
            {
                Status = (byte)OpportuniteStatus.Pending,
                Type = (byte)OpportuniteType.NewInsurance,
                Insured = new Infrastructure.Repository.Leads.Commands.Insured
                {
                    BirthDate = command.Insured.BirthDate,
                    Cpf = command.Insured.Cpf,
                    Email = command.Insured.Email,
                    Gender = command.Insured.Gender,
                    Name = command.Insured.Name,
                    PersonType = command.Insured.PersonType,
                    PhoneNumber = command.Insured.PhoneNumber
                },
                CreateAt = DateTime.Now,
            },
            CreatedAt = DateTime.Now,
            Status = (byte)SolicitationStatus.Pending,
            QuotationToken = Guid.NewGuid().ToString(),
            Address = new Infrastructure.Repository.Leads.Commands.Address
            {
                City = command.Address.City,
                Number = command.Address.Number,
                Complement = command.Address.Complement,
                Neighborhood = command.Address.Neighborhood,
                State = command.Address.State,
                Street = command.Address.Street,
                ZipCode = command.Address.ZipCode
            }
        };
    }
}