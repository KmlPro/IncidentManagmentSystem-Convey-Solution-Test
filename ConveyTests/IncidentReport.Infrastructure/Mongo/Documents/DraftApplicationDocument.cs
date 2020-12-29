using System;

namespace IncidentReport.Infrastructure.Mongo.Documents
{
    internal sealed class DraftApplicationDocument
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public int DateCreated { get; set; }
    }
}