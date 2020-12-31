using System;
using IncidentReport.Core.Events;
using IncidentReport.Core.Exceptions;

namespace IncidentReport.Core.Entities
{
    public class PostedApplication : AggregateRoot
    {
        public string Content { get; }
        public string Title { get; }
        public DateTime DateCreated { get; }
        
        public PostedApplication(Guid id, string content,string title,DateTime dateCreated,
            int version = 0)
        {
            ValidateContent(content);
            
            Id = id;
            Content = content;
            Title = title;
            Version = version;
            DateCreated = dateCreated;
        }

        private static void ValidateContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ContentIsEmptyException();
            }
        }

        public static PostedApplication Create(Guid id, string content,string title, DateTime dateCreated)
        {
            var postedApplication = new PostedApplication(id, content, title, dateCreated);
            postedApplication.AddEvent(new PostedApplicationCreated(postedApplication));
            return postedApplication;
        }
    }
}