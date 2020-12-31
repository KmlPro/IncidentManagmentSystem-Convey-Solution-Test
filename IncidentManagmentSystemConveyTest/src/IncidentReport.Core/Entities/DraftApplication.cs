using System;
using IncidentReport.Core.Events;
using IncidentReport.Core.Exceptions;

namespace IncidentReport.Core.Entities
{
    public class DraftApplication : AggregateRoot
    {
        public string Content { get; }
        public string Title { get; }
        public DateTime DateCreated { get; }
        public bool ReadyToPost { get; private set; }
        
        public DraftApplication(Guid id, string content,string title,DateTime dateCreated,bool readyToPost,
            int version = 0)
        {
            ValidateContent(content);
            
            Id = id;
            Content = content;
            Title = title;
            Version = version;
            DateCreated = dateCreated;
            ReadyToPost = readyToPost;
        }

        private static void ValidateContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ContentIsEmptyException();
            }
        }

        public static DraftApplication Create(Guid id, string content,string title, DateTime dateCreated)
        {
            var draftApplication = new DraftApplication(id, content, title, dateCreated, false);
            draftApplication.AddEvent(new DraftApplicationCreated(draftApplication));
            return draftApplication;
        }

        public void MarkAsReadyToPost()
        {
            if (DraftApplicationIsAlreadyMarkedAsReadyToPost(ReadyToPost))
            {
                throw new DraftApplicationAlreadyMarkedAsReadyToPostException(Id);
            }

            ReadyToPost = true;
            AddEvent(new DraftApplicationMarkedAsReadyToPost(this));

            bool DraftApplicationIsAlreadyMarkedAsReadyToPost(in bool readyToPost) => readyToPost == true;
        }
    }
}