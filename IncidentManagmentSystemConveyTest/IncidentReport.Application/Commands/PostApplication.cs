using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class PostApplication : ICommand
    {
        public Guid Id { get; }
        public string Content { get; }
        public string Title { get; }

        public PostApplication(Guid id, string content, string title)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Content = content;
            Title = title;
        }
    }
}