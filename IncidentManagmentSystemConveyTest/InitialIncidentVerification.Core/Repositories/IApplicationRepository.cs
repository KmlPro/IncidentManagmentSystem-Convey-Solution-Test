using System.Threading.Tasks;
using InitialIncidentVerification.Entities;

namespace InitialIncidentVerification.Repositories
{
    public interface IApplicationRepository
    {
        Task<Application> GetAsync(AggregateId id);
        Task<bool> ExistsAsync(AggregateId id);
        Task AddAsync(Application resource);
    }
}