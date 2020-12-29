using System;
using Convey.Types;

namespace IncidentReport.Infrastructure.Mongo.Documents.DraftApplication
{
    internal sealed class DraftApplicationDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public int DateCreated { get; set; }
        
        public bool ReadyToPost { get; set; }
    }
}