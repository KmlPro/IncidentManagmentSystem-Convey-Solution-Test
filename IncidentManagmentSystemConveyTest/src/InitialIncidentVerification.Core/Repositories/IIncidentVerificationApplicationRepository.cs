using System.Threading.Tasks;
using InitialIncidentVerification.Entities;

namespace InitialIncidentVerification.Repositories
{
    public interface IIncidentVerificationApplicationRepository
    {
        Task<IncidentVerificationApplication> GetAsync(AggregateId id);
        Task<bool> ExistsAsync(AggregateId id);
        Task AddAsync(IncidentVerificationApplication resource);
    }
}