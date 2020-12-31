using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace IncidentReport.Application.Events.External.Handlers
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        public Task HandleAsync(SignedUp @event)
        {
            return Task.CompletedTask;
        }
    }
}