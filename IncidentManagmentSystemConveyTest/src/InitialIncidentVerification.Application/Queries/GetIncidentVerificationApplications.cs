using System.Collections.Generic;
using Convey.CQRS.Queries;
using InitialIncidentVerification.Application.DTO;

namespace InitialIncidentVerification.Application.Queries
{
    public class GetIncidentVerificationApplications: IQuery<IEnumerable<IncidentVerificationApplicationDto>>
    {
        
    }
}