using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Events
{
    public class PostedApplicationCreated : IDomainEvent
    {
        public PostedApplication PostedApplication { get; }
        public PostedApplicationCreated(PostedApplication postedApplication)
            => PostedApplication = postedApplication;
    }
}