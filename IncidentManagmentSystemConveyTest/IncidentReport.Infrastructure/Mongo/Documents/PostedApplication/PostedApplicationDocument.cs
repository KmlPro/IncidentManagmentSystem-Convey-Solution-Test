using System;
using Convey.Types;

namespace IncidentReport.Infrastructure.Mongo.Documents.PostedApplication
{
    internal sealed class PostedApplicationDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public int DateCreated { get; set; }
    }
}