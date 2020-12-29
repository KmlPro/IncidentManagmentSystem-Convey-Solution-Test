using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using IncidentReport.Application.Events;
using IncidentReport.Application.Services;
using IncidentReport.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IncidentReport.Infrastructure.Services
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<IEventProcessor> _logger;

        public EventProcessor(IServiceScopeFactory serviceScopeFactory, IEventMapper eventMapper,
            IMessageBroker messageBroker, ILogger<IEventProcessor> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _logger = logger;
        }
        
        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null)
            {
                return;
            }

            var integrationEvents = await HandleDomainEventsAsync(events);
            if (!integrationEvents.Any())
            {
                return;
            }

            await _messageBroker.PublishAsync(integrationEvents);
        }

        private async Task<List<IEvent>> HandleDomainEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            var integrationEvents = new List<IEvent>();
            using var scope = _serviceScopeFactory.CreateScope();
            foreach (var domainEvent in domainEvents)
            {
                var domainEventType = domainEvent.GetType();
                _logger.LogTrace($"Handling a domain event {domainEventType.Name}");

                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEventType);
                
                dynamic handlers = scope.ServiceProvider.GetServices(handlerType);

                if (handlers != null)
                {
                    foreach (var handler in handlers)
                    {
                        await handler.HandleAsync((dynamic) domainEvent);
                    }
                }

                var integrationEvent = _eventMapper.Map(domainEvent);
                if (integrationEvent is null)
                {
                    continue;
                }
                
                integrationEvents.Add(integrationEvent);
            }

            return integrationEvents;
        }
    }
}