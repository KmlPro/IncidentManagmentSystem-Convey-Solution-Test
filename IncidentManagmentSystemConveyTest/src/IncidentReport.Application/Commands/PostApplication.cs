using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    [Contract]
    public class PostApplication : ICommand
    {
        public PostApplication(Guid postedApplicationId, string content, string title)
        {
            PostedApplicationId = postedApplicationId == Guid.Empty ? Guid.NewGuid() : postedApplicationId;
            Content = content;
            Title = title;
        } 
        public Guid PostedApplicationId { get; }
        public string Content { get; }
        public string Title { get; }
    }
}