using System.Threading.Tasks;
using IncidentReport.Core.Entities;

namespace IncidentReport.Core.Repositories
{
    public interface IPostedApplicationRepository
    {
        Task<PostedApplication> GetAsync(AggregateId id);
        Task<bool> ExistsAsync(AggregateId id);
        Task AddAsync(PostedApplication resource);
        Task UpdateAsync(PostedApplication resource);
        Task DeleteAsync(AggregateId id);
    }
}