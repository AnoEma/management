using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public interface IQuotationApiHttpClient
{
    Task<Result> CreatQuotationAsync(QuotationCommand command, CancellationToken cancellationToken = default);
}