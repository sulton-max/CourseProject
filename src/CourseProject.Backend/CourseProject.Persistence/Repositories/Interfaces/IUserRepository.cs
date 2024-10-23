﻿using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(
             Expression<Func<User, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<User?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}