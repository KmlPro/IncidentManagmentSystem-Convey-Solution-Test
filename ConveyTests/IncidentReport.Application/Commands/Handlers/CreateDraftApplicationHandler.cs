using System.Threading.Tasks;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands.Handlers
{
    public class CreateDraftApplicationHandler : ICommandHandler<CreateDraftApplication>
    {
        public Task HandleAsync(CreateDraftApplication command)
        {
            return Task.CompletedTask;
        }
    }
}