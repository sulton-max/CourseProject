﻿using CourseProject.Application.Answers.Models;
using CourseProject.Application.Questions.Models;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Application.Questions.Services;

public interface IQuestionService
{
    IQueryable<Question> Get(
             Expression<Func<Question, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Question> Get(
        QuestionFilter questionFilter,
        QueryOptions queryOptions = default);

    ValueTask<Question?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Question>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Question> CreateAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Question> UpdateAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Question?> DeleteAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Question?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}