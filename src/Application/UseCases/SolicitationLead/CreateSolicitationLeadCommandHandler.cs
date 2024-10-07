using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Quotations.HttpClients;

namespace Application.UseCases.SolicitationLead;

public class CreateSolicitationLeadCommandHandler(IQuotationApiHttpClient quotationApiHttpClient) : ICreateSolicitationLeadCommandHandler
{
    public async Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default)
    {
        QuotationCommand requestCommand = CreateRequestCommand(command);
        Result result = await quotationApiHttpClient.CreatQuotationAsync(requestCommand, cancellationToken);

        if (result.IsFailure)
        {
            
        }

        return result;
    }

    private QuotationCommand CreateRequestCommand(CreateSolicitationLeadCommand command)
    {
        throw new NotImplementedException();
    }
}
