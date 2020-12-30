using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using InitialIncidentVerification.Application.Events.External;
using InitialIncidentVerification.Entities;
using InitialIncidentVerification.Repositories;

namespace InitialIncidentVerification.Application.Commands.Handlers
{
    public class CreateIncidentVerificationApplicationHandler : ICommandHandler<CreateIncidentVerificationApplication>
    {
        private readonly IIncidentVerificationApplicationRepository _repository;

        public CreateIncidentVerificationApplicationHandler(IIncidentVerificationApplicationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task HandleAsync(CreateIncidentVerificationApplication command)
        {
            if (await _repository.ExistsAsync(command.PostedApplicationId))
            {
                return;
            }
            
            var application = IncidentVerificationApplication.Create(command.PostedApplicationId, command.Content, command.Title, DateTime.Now);
            await _repository.AddAsync(application);
        }
    }
}