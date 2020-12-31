using System;

namespace IncidentReport.Core.Exceptions
{
    public class DraftApplicationAlreadyMarkedAsReadyToPostException : DomainException
    {
        public override string Code { get; } = "draft-application-is-marked-as-ready-to-post";
        
        public DraftApplicationAlreadyMarkedAsReadyToPostException(Guid id) : base($"Draft application with id {id} is already marked as ready to post")
        {
        }
    }
}