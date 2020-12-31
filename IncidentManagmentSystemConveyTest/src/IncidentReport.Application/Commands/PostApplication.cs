using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class PostApplication : ICommand
    {
        public PostApplication(Guid id, string content, string title)
        {
            PostedApplicationId = id == Guid.Empty ? Guid.NewGuid() : id;
            Content = content;
            Title = title;
        } 
        public Guid PostedApplicationId { get; }
        public string Content { get; }
        public string Title { get; }
    }
}