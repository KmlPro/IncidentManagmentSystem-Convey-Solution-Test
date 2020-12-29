using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using IncidentReport.Core.Entities;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace IncidentReport.Infrastructure.Mongo.Repositories
{
    internal sealed class DraftApplicationMongoRepository : IDraftApplicationRepository
    {
        private readonly IMongoRepository<DraftApplicationDocument, Guid> _repository;
        
        public DraftApplicationMongoRepository(IMongoRepository<DraftApplicationDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<DraftApplication> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(AggregateId id)
            => _repository.ExistsAsync(r => r.Id == id);

        public Task AddAsync(DraftApplication resource)
            => _repository.AddAsync(resource.AsDocument());

        public Task UpdateAsync(DraftApplication resource)
            => _repository.Collection.ReplaceOneAsync(r => r.Id == resource.Id && r.Version < resource.Version,
                resource.AsDocument());

        public Task DeleteAsync(AggregateId id)
            => _repository.DeleteAsync(id);
    }
}