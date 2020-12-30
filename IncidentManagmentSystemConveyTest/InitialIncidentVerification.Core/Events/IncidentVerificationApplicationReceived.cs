using InitialIncidentVerification.Entities;

namespace InitialIncidentVerification.Events
{
    public class IncidentVerificationApplicationReceived : IDomainEvent
    {
        public IncidentVerificationApplication IncidentVerificationApplication { get; }
        public IncidentVerificationApplicationReceived(IncidentVerificationApplication incidentVerificationApplication)
            => IncidentVerificationApplication = incidentVerificationApplication;
    }
}