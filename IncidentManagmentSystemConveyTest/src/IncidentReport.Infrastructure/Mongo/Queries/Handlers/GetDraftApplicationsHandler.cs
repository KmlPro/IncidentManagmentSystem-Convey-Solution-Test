using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;
using IncidentReport.Application.Queries;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace IncidentReport.Infrastructure.Mongo.Queries.Handlers
{
    public class GetDraftApplicationsHandler : IQueryHandler<GetDraftApplications, IEnumerable<DraftApplicationDto>>
    {
        private readonly IMongoDatabase _database;

        public GetDraftApplicationsHandler(IMongoDatabase database)
        {
            _database = database;
        }
        
        public async Task<IEnumerable<DraftApplicationDto>> HandleAsync(GetDraftApplications query)
        {
            var collection = _database.GetCollection<DraftApplicationDocument>("draft-applications");

            if (string.IsNullOrEmpty(query.Content) && string.IsNullOrEmpty(query.Title))
            {
                var allDocuments = await collection.Find(_ => true).ToListAsync();
                return allDocuments.Select(d => d.AsDto());
            }

            var documents = collection.AsQueryable();

            if (!string.IsNullOrEmpty(query.Content))
            {
                documents = documents.Where(d => d.Content == query.Content);
            }
            
            if (!string.IsNullOrEmpty(query.Title))
            {
                documents = documents.Where(d => d.Title == query.Title);
            }

            var draftAppplicationDocuments = await documents.ToListAsync();
            return draftAppplicationDocuments.Select(d => d.AsDto());
        }
    }
}