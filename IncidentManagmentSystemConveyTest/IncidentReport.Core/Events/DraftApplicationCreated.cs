using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Events
{
    public class DraftApplicationCreated : IDomainEvent
    {
        public DraftApplication Resource { get; }

        public DraftApplicationCreated(DraftApplication resource)
            => Resource = resource;
    }
}