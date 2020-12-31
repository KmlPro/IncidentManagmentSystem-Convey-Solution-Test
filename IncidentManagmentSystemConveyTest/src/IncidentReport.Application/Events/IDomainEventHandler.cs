using System.Threading.Tasks;
using IncidentReport.Core.Events;

namespace IncidentReport.Application.Events
{
    public interface IDomainEventHandler<in T> where T: class, IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}