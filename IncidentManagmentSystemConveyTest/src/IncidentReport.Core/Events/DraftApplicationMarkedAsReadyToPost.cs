using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Events
{
    public class DraftApplicationMarkedAsReadyToPost : IDomainEvent
    {
        public DraftApplication DraftApplication { get; }

        public DraftApplicationMarkedAsReadyToPost(DraftApplication draftApplication)
            => DraftApplication = draftApplication;
    }
}