using System;

namespace IncidentReport.Application.DTO
{
    public class PostedApplicationDto
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string Title { get; set; }

        public int Version { get; set; }
        
        public DateTime DateCreated { get; set; }
    }
}