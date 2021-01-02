using System.Collections.Generic;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;

namespace IncidentReport.Application.Queries
{
    public class GetPostedApplications: IQuery<IEnumerable<PostedApplicationDto>>
    {
        
    }
}