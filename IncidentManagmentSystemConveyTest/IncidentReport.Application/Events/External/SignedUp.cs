using System;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events.External
{
 //   [Message("identity")]
    public class SignedUp : IEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Role { get; }
        
        public SignedUp(Guid userId, string email, string role)
        {
            UserId = userId;
            Email = email;
            Role = role;
        }
    }
}