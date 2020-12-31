using System;
using Convey.Types;

namespace InitialIncidentVerification.Infrastructure.Mongo.Documents
{
    internal sealed class IncidentVerificationApplicationDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public int DateReceived { get; set; }
    }
}