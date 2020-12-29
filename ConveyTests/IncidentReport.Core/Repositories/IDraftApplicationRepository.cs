using System.Threading.Tasks;
using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Repositories
{
    public interface IDraftApplicationRepository
    {
        Task<DraftApplication> GetAsync(AggregateId id);
        Task<bool> ExistsAsync(AggregateId id);
        Task AddAsync(DraftApplication resource);
        Task UpdateAsync(DraftApplication resource);
        Task DeleteAsync(AggregateId id);
    }
}