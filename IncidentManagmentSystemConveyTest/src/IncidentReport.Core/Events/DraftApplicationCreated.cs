using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Events
{
    public class DraftApplicationCreated : IDomainEvent
    {
        public DraftApplication DraftApplication { get; }
        public DraftApplicationCreated(DraftApplication draftApplication)
            => DraftApplication = draftApplication;
    }
}