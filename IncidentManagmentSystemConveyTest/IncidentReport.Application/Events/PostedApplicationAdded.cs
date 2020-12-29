using System;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events
{
    [Contract]
    public class PostedApplicationAdded : IEvent
    {
        public Guid Id { get; }

        public PostedApplicationAdded(Guid id)
        {
            Id = id;
        }
    }
}