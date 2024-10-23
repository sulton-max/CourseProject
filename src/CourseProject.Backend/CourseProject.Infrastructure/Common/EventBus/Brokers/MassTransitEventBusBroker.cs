﻿using CourseProject.Application.Common.EventBus.Brokers;
using CourseProject.Domain.Common.Events;
using MassTransit;
using MediatR;

namespace CourseProject.Infrastructure.Common.EventBus.Brokers;

public class MassTransitEventBusBroker(IBus bus, IPublisher publisher) : IEventBusBroker
{
    public async ValueTask PublishAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
        await publisher.Publish(@event, cancellationToken);

    public async ValueTask PublishLocalAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
        await bus.Publish(@event, cancellationToken);
}