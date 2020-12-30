using System;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events
{
    [Contract]
    public class PostedApplicationAdded : IEvent
    {
        public PostedApplicationAdded(Guid id, string content, string title)
        {
            Id = id;
            Content = content;
            Title = title;
        }
        
        public Guid Id { get; }
        public string Content { get; }
        public string Title { get; }
    }
}