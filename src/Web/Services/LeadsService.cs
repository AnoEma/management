using Application.Model;
using Application.UseCases.Addresses;
using Application.UseCases.Addresses.Models;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
using Application.UseCases.Vehicles;
using Application.UseCases.Vehicles.Models;
using CSharpFunctionalExtensions;
using Web.Model;
using Web.Services.Interfaces;

namespace Web.Services;

internal class LeadsService(
    ISolicitationLeadQueryHandler queryHandler,
    ICreateSolicitationLeadCommandHandler commandHandler,
    IGetAddressQueryHandler addressQueryHandler,
    IGetVehicleQueryHandler vehicleQueryHandler
) : ILeadsService
{
    public async Task<Result> CreateLead(CreateLeadModel model, CancellationToken cancellationToken)
    {
        CreateSolicitationLeadCommand command = CreateLeadModel.CreateCommand(model);

        Result result = await commandHandler.HandleAsync(command, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Result>($"Erro... {result.Error}");
        }

        return Result.Success(result);
    }

    public async Task<Result<IReadOnlyList<LeadsModel>>> GetLeads(CancellationToken cancellationToken)
    {
        Result<IReadOnlyList<Solicitation>> result = await queryHandler.HandlerAsync(cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<IReadOnlyList<LeadsModel>>(result.Error);
        }

        IReadOnlyList<LeadsModel> response = LeadsModel.CreateLeadsModel(result.Value);

        return Result.Success(response);
    }

    public async Task<Result<GetAddressResponse>> GetAddress(string zipCode, CancellationToken cancellationToken)
    {
        GetAddressQuery addressQuery = new(zipCode);
        Result<GetAddressResponse> result = await addressQueryHandler.HandlerAsync(addressQuery, cancellationToken);

        if (result.IsFailure)
        {

        }
        return result;
    }

    public async Task<Result<GetVehicleResponse>> GetVehicle(string plate, CancellationToken cancellationToken)
    {
        GetVehicleQuery vehicleQuery = new(plate);
        Result<GetVehicleResponse> result = await vehicleQueryHandler.HandlerAsync(vehicleQuery, cancellationToken);

        if (result.IsFailure)
        {

        }
        return result;
    }
}
