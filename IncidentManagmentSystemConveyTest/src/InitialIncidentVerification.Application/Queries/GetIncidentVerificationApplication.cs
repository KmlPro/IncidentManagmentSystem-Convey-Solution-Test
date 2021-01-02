using System;
using Convey.CQRS.Queries;
using InitialIncidentVerification.Application.DTO;

namespace InitialIncidentVerification.Application.Queries
{
    public class GetIncidentVerificationApplication: IQuery<IncidentVerificationApplicationDto>
    {
        public Guid IncidentVerificationApplicationId { get; set; }
    }
}