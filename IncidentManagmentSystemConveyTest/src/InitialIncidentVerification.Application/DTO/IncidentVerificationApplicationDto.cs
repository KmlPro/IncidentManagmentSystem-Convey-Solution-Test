using System;

namespace InitialIncidentVerification.Application.DTO
{
    public class IncidentVerificationApplicationDto
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public DateTime DateReceived { get; set; }
    }
}