using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using InitialIncidentVerification.Application.Exceptions;
using InitialIncidentVerification.Entities;
using InitialIncidentVerification.Repositories;

namespace InitialIncidentVerification.Application.Events.External.Handlers
{
    public class PostedApplicationAddedHandler : IEventHandler<PostedApplicationAdded>
    {
        private readonly IIncidentVerificationApplicationRepository _repository;

        public PostedApplicationAddedHandler(IIncidentVerificationApplicationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task HandleAsync(PostedApplicationAdded @event)
        {
            if (await _repository.ExistsAsync(@event.PostedApplicationId))
            {
                throw new PostedApplicationAlreadyAddedException(@event.PostedApplicationId);
            }
            
            var application = IncidentVerificationApplication.Create(@event.PostedApplicationId, @event.Content, @event.Title, DateTime.Now);
            await _repository.AddAsync(application);
        }
    }
}