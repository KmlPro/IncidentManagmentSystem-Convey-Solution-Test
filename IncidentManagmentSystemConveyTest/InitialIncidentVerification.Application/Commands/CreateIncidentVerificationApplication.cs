using System;
using Convey.CQRS.Commands;

namespace InitialIncidentVerification.Application.Commands
{
    public class CreateIncidentVerificationApplication : ICommand
    {
        public CreateIncidentVerificationApplication(Guid postedApplicationId, string content, string title)
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