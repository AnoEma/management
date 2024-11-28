using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public interface IQuotationApiHttpClient
{
    Task<Result<QuotationResponse>> CreatQuotationAsync(QuotationRequest command, CancellationToken cancellationToken = default);
}