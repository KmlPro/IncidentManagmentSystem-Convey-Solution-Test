using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class CreateDraftApplication : ICommand
    {
        public Guid Id { get; }
        public string Content { get; }
        public string Title { get; }

        public CreateDraftApplication(Guid draftApplicationId, string content, string title)
        {
            Id = draftApplicationId == Guid.Empty ? Guid.NewGuid() : draftApplicationId;
            Content = content;
            Title = title;
        }
    }
}