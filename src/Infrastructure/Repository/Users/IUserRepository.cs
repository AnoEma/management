﻿using CSharpFunctionalExtensions;
using Infrastructure.Repository.Users.Commands;

namespace Infrastructure.Repository.Users;

public interface IUserRepository
{
    Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default);
    Task<Result<List<User>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<User>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<int>> SaveAsync(User command, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(User command, CancellationToken cancellationToken = default);
}