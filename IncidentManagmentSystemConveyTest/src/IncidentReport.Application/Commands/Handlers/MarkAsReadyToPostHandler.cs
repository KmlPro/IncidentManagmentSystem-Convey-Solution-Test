using System.Threading.Tasks;
using Convey.CQRS.Commands;
using IncidentReport.Application.Exceptions;
using IncidentReport.Core.Repositories;

namespace IncidentReport.Application.Commands.Handlers
{
    public class MarkAsReadyToPostHandler: ICommandHandler<MarkAsReadyToPost>
    {
        private readonly IDraftApplicationRepository _draftApplicationRepository;

        public MarkAsReadyToPostHandler(IDraftApplicationRepository draftApplicationRepository)
        {
            _draftApplicationRepository = draftApplicationRepository;
        }

        public async Task HandleAsync(MarkAsReadyToPost command)
        {
            var draftApplication = await _draftApplicationRepository.GetAsync(command.DraftApplicationId);
            
            if (draftApplication is null)
            {
                throw new DraftApplicationNotFoundException(command.DraftApplicationId);
            }

            draftApplication.MarkAsReadyToPost();
            await _draftApplicationRepository.UpdateAsync(draftApplication);
        }
    }
}