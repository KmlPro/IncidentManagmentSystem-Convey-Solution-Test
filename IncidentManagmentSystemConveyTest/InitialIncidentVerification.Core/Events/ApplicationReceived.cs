using InitialIncidentVerification.Entities;

namespace InitialIncidentVerification.Events
{
    public class ApplicationReceived : IDomainEvent
    {
        public Application Application { get; }
        public ApplicationReceived(Application application)
            => Application = application;
    }
}