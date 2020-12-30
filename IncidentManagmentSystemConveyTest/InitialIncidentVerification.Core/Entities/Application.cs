using System;
using InitialIncidentVerification.Events;

namespace InitialIncidentVerification.Entities
{
    public class Application : AggregateRoot
    {
        public string Content { get; }
        public string Title { get; }
        public DateTime DateReceived { get; }

        public Application(Guid id, string content, string title, DateTime dateReceived)
        {
            Id = id;
            Content = content;
            Title = title;
            DateReceived = dateReceived;
        }
        
        public static Application Create(Guid id, string content,string title, DateTime dateCreated)
        {
            var application = new Application(id, content, title, dateCreated);
            application.AddEvent(new ApplicationReceived(application));
            return application;
        }
    }
}