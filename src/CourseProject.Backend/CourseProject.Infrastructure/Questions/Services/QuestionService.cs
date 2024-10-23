﻿using CourseProject.Application.Questions.Models;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using CourseProject.Infrastructure.Questions.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Questions.Services;

public class QuestionService(
    IQuestionRepository questionRepository,
    QuestionValidator validator)
   : IQuestionService
{
    public IQueryable<Question> Get(
        Expression<Func<Question, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    questionRepository.Get(predicate, queryOptions);

    public IQueryable<Question> Get(
        QuestionFilter questionFilter,
        QueryOptions queryOptions = default) =>
    questionRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(questionFilter);

    public ValueTask<Question?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    questionRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Question>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    questionRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    questionRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Question> CreateAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            question,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await questionRepository.CreateAsync(question, commandOptions, cancellationToken);
    }

    public async ValueTask<Question> UpdateAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            question,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await questionRepository.UpdateAsync(question, commandOptions, cancellationToken);
    }

    public ValueTask<Question?> DeleteAsync(
        Question question,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    questionRepository.DeleteAsync(question, commandOptions, cancellationToken);

    public ValueTask<Question?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    questionRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}