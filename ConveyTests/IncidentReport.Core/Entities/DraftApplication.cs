using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Core.Events;
using IncidentReport.Core.Exceptions;

namespace IncidentReport.Core.Entities
{
    public class DraftApplication : AggregateRoot
    {
        public string Content { get; }
        public string Title { get; }
        
        public DraftApplication(Guid id, string content,string title,
            int version = 0)
        {
            ValidateContent(content);
            
            Id = id;
            Content = content;
            Title = title;
            Version = version;
        }

        private static void ValidateContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ContentIsEmptyException();
            }
        }

        public static DraftApplication Create(Guid id, string content,string title)
        {
            var draftApplication = new DraftApplication(id, content, title);
            draftApplication.AddEvent(new DraftApplicationCreated(draftApplication));
            return draftApplication;
        }
    }
}