using System.Collections.Generic;
using System.Threading.Tasks;
using IncidentReport.Core.Events;

namespace IncidentReport.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}