using System;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events
{
    [Contract]
    public class PostedApplicationAdded : IEvent
    {
        public PostedApplicationAdded(Guid postedApplicationId, string content, string title)
        {
            PostedApplicationId = postedApplicationId;
            Content = content;
            Title = title;
        }
        
        public Guid PostedApplicationId { get; }
        public string Content { get; }
        public string Title { get; }
    }
}