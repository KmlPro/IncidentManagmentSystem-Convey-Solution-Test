using System;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;

namespace IncidentReport.Application.Queries
{
    public class GetPostedApplication: IQuery<PostedApplicationDto>
    {
        public Guid PostedApplicationId { get; set; }
    }
}