using System;
using InitialIncidentVerification.Events;

namespace InitialIncidentVerification.Entities
{
    public class IncidentVerificationApplication : AggregateRoot
    {
        public string Content { get; }
        public string Title { get; }
        public DateTime DateReceived { get; }

        public IncidentVerificationApplication(Guid id, string content, string title, DateTime dateReceived)
        {
            Id = id;
            Content = content;
            Title = title;
            DateReceived = dateReceived;
        }
        
        public static IncidentVerificationApplication Create(Guid id, string content,string title, DateTime dateCreated)
        {
            var application = new IncidentVerificationApplication(id, content, title, dateCreated);
            application.AddEvent(new IncidentVerificationApplicationReceived(application));
            return application;
        }
    }
}