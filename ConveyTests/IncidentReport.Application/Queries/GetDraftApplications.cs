using System.Collections.Generic;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;

namespace IncidentReport.Application.Queries
{
    public class GetDraftApplications : IQuery<IEnumerable<DraftApplicationDto>>
    {
        public string Content { get; set; }
        public string Title { get; set; }
    }
}