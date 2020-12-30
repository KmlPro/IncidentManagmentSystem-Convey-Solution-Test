using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using InitialIncidentVerification.Application.Commands;

namespace InitialIncidentVerification.Application.Events.External.Handlers
{
    public class PostedApplicationAddedHandler : IEventHandler<PostedApplicationAdded>
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public PostedApplicationAddedHandler(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task HandleAsync(PostedApplicationAdded @event) => await _commandDispatcher.SendAsync(
            new CreateIncidentVerificationApplication(@event.PostedApplicationId, @event.Content, @event.Title));
    }
}