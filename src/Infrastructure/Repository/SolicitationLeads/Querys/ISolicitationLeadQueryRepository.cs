﻿using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.SolicitationLeads.Querys;

public interface ISolicitationLeadQueryRepository
{
    Task<Result> GetSolicitationLeadByDocumentAsync(string document, CancellationToken cancellationToken = default);
    Task<Result<List<SolicitationLead>>> GetSolicitationLeadAsync(CancellationToken cancellationToken = default);
}