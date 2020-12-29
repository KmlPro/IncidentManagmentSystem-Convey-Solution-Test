using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using IncidentReport.Core.Entities;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Mongo.Documents;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using IncidentReport.Infrastructure.Mongo.Documents.PostedApplication;
using MongoDB.Driver;

namespace IncidentReport.Infrastructure.Mongo.Repositories
{
    internal sealed class PostedApplicationMongoRepository : IPostedApplicationRepository
    {
        private readonly IMongoRepository<PostedApplicationDocument, Guid> _repository;
        
        public PostedApplicationMongoRepository(IMongoRepository<PostedApplicationDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<PostedApplication> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(AggregateId id)
            => _repository.ExistsAsync(r => r.Id == id);

        public Task AddAsync(PostedApplication resource)
            => _repository.AddAsync(resource.AsDocument());

        public Task UpdateAsync(PostedApplication resource)
            => _repository.Collection.ReplaceOneAsync(r => r.Id == resource.Id && r.Version < resource.Version,
                resource.AsDocument());

        public Task DeleteAsync(AggregateId id)
            => _repository.DeleteAsync(id);
    }
}