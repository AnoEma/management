using Application.UseCases.Addresses.Models;
using Application.UseCases.Vehicles.Models;
using CSharpFunctionalExtensions;
using Web.Model;

namespace Web.Services.Interfaces;

public interface ILeadsService
{
    Task<Result<IReadOnlyList<LeadsModel>>> GetLeads(CancellationToken cancellationToken);
    Task<Result> CreateLead(CreateLeadModel model, CancellationToken cancellationToken);
    Task<Result<GetAddressResponse>> GetAddress(string zipCode, CancellationToken cancellationToken);
    Task<Result<GetVehicleResponse>> GetVehicle(string plate, CancellationToken cancellationToken);
}