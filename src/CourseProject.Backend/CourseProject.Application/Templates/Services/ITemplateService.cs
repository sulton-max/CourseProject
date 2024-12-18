﻿using CourseProject.Application.Answers.Models;
using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Application.Templates.Services;

public interface ITemplateService
{
    IQueryable<Template> Get(
             Expression<Func<Template, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Template> Get(
        TemplateFilter templateFilter,
        QueryOptions queryOptions = default);

    ValueTask<Template?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Template>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Template> CreateAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Template> UpdateAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Template?> DeleteAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Template?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
