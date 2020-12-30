using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Convey.MessageBrokers.Outbox;
using IncidentReport.Application.Services;

namespace IncidentReport.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IMessageOutbox _outbox;
        private readonly OutboxOptions _outboxOptions;
        private readonly IMessagePropertiesAccessor _messagePropertiesAccessor;

        public MessageBroker(IBusPublisher busPublisher, IMessageOutbox outbox, OutboxOptions outboxOptions, IMessagePropertiesAccessor messagePropertiesAccessor)
        {
            _busPublisher = busPublisher;
            _outbox = outbox;
            _outboxOptions = outboxOptions;
            _messagePropertiesAccessor = messagePropertiesAccessor;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }

            var originatedMessageId = _messagePropertiesAccessor.MessageProperties?.MessageId;

            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }

                var messageId = Guid.NewGuid().ToString("N");
                if (_outboxOptions.Enabled)
                {
                    await _outbox.SendAsync(@event, originatedMessageId, messageId);
                    continue;
                }
                
                await _busPublisher.PublishAsync(@event, messageId);
            }
        }
    }
}