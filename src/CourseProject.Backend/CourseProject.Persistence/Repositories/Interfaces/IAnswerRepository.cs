﻿using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories.Interfaces;

public interface IAnswerRepository
{
    IQueryable<Answer> Get(
             Expression<Func<Answer, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<Answer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Answer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Answer> CreateAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Answer> UpdateAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Answer?> DeleteAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Answer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}