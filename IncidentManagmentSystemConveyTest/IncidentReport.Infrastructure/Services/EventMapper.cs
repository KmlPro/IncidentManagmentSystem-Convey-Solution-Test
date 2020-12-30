using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Events;
using IncidentReport.Application.Events;
using IncidentReport.Application.Services;
using IncidentReport.Core.Events;

namespace IncidentReport.Infrastructure.Services
{
    public class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
            => @event switch
            {    
                PostedApplicationCreated e => new PostedApplicationAdded(e.PostedApplication.Id, e.PostedApplication.Content, e.PostedApplication.Title),
                _ => null
            };

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events) => events.Select(Map);
    }
}