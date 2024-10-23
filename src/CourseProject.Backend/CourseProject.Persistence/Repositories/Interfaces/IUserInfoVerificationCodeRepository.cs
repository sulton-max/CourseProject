﻿using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories.Interfaces;

public interface IUserInfoVerificationCodeRepository
{
    IQueryable<UserInfoVerificationCode> Get(
             Expression<Func<UserInfoVerificationCode, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<UserInfoVerificationCode?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<UserInfoVerificationCode>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<UserInfoVerificationCode> CreateAsync(
        UserInfoVerificationCode userInfoVerificationCode,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask DeactivateAsync(
        Guid codeId,
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}