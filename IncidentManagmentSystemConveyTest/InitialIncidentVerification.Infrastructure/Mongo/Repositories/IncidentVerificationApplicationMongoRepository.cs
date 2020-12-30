using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using InitialIncidentVerification.Entities;
using InitialIncidentVerification.Infrastructure.Mongo.Documents;
using InitialIncidentVerification.Repositories;

namespace InitialIncidentVerification.Infrastructure.Mongo.Repositories
{
    internal sealed class IncidentVerificationApplicationMongoRepository : IIncidentVerificationApplicationRepository
    {
        private readonly IMongoRepository<IncidentVerificationApplicationDocument, Guid> _repository;
        
        public IncidentVerificationApplicationMongoRepository(IMongoRepository<IncidentVerificationApplicationDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<IncidentVerificationApplication> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(AggregateId id)
            => _repository.ExistsAsync(r => r.Id == id);

        public Task AddAsync(IncidentVerificationApplication resource)
            => _repository.AddAsync(resource.AsDocument());
    }
}