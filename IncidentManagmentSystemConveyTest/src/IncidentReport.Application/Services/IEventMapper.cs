using System.Collections.Generic;
using Convey.CQRS.Events;
using IncidentReport.Core.Events;

namespace IncidentReport.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> @events);
    }
}