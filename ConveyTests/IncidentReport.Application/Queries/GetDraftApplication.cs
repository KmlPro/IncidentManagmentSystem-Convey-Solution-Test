using System;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;

namespace IncidentReport.Application.Queries
{
    public class GetDraftApplication : IQuery<DraftApplicationDto>
    {
        public Guid DraftApplicationId { get; set; }
    }
}