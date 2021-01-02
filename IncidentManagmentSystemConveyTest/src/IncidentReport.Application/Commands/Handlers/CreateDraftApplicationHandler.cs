using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using IncidentReport.Application.Exceptions;
using IncidentReport.Core.Entities;
using IncidentReport.Core.Repositories;

namespace IncidentReport.Application.Commands.Handlers
{
    public class CreateDraftApplicationHandler : ICommandHandler<CreateDraftApplication>
    {
        private readonly IDraftApplicationRepository _draftApplicationRepository;

        public CreateDraftApplicationHandler(IDraftApplicationRepository draftApplicationRepository)
        {
            _draftApplicationRepository = draftApplicationRepository;
        }
        
        public async Task HandleAsync(CreateDraftApplication command)
        {
            if (await _draftApplicationRepository.ExistsAsync(command.DraftApplicationId))
            {
                throw new DraftApplicationAlreadyExistsException(command.DraftApplicationId);
            }

            var draftApplication = DraftApplication.Create(command.DraftApplicationId, command.Content, command.Title, DateTime.Now);
            await _draftApplicationRepository.AddAsync(draftApplication);
        }
    }
}