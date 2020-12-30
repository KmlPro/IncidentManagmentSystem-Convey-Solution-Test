using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using IncidentReport.Application.Exceptions;
using IncidentReport.Application.Services;
using IncidentReport.Core.Entities;
using IncidentReport.Core.Repositories;

namespace IncidentReport.Application.Commands.Handlers
{
    public class PostApplicationHandler : ICommandHandler<PostApplication>
    {
        private readonly IPostedApplicationRepository _repository;
        private readonly IEventProcessor _eventProcessor;
        public PostApplicationHandler(IPostedApplicationRepository repository, IMessageBroker messageBroker, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }
       
        public async Task HandleAsync(PostApplication command)
        {
            if (await _repository.ExistsAsync(command.PostedApplicationId))
            {
                throw new PostedApplicationAlreadyExistsException(command.PostedApplicationId);
            }
            
            var postedApplication = PostedApplication.Create(command.PostedApplicationId, command.Content, command.Title, DateTime.Now);
            await _repository.AddAsync(postedApplication);
            await _eventProcessor.ProcessAsync(postedApplication.Events);
        }
    }
}