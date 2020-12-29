using System;
using Convey.MessageBrokers.RabbitMQ;
using IncidentReport.Application.Events.Rejected;
using IncidentReport.Application.Exceptions;
using IncidentReport.Core.Exceptions;

namespace IncidentReport.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                ContentIsEmptyException ex => new PostedApplicationRejected(Guid.Empty, ex.Message, ex.Code),
                PostedApplicationAlreadyExistsException ex => new PostedApplicationRejected(ex.PostedApplicationId, ex.Message, ex.Code),
                _ => null
            };
    }
}