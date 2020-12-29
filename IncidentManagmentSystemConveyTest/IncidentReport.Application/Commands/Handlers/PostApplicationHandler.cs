using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using IncidentReport.Application.Exceptions;
using IncidentReport.Core.Entities;
using IncidentReport.Core.Repositories;

namespace IncidentReport.Application.Commands.Handlers
{
    public class PostApplicationHandler : ICommandHandler<PostApplication>
    {
        private readonly IPostedApplicationRepository _repository;

        public PostApplicationHandler(IPostedApplicationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task HandleAsync(PostApplication command)
        {
            if (await _repository.ExistsAsync(command.Id))
            {
                throw new PostedApplicationAlreadyExistsException(command.Id);
            }
            
            var postedApplication = PostedApplication.Create(command.Id, command.Content, command.Title, DateTime.Now);
            await _repository.AddAsync(postedApplication);
        }
    }
}