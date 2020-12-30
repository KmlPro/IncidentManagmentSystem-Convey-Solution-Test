using System;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events.Rejected
{
    [Contract]
    public class PostApplicationRejected : IRejectedEvent
    {
        public PostApplicationRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
        
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}