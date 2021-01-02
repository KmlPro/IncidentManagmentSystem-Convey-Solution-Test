using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;
using IncidentReport.Application.Queries;
using IncidentReport.Infrastructure.Mongo.Documents.PostedApplication;
using MongoDB.Driver;

namespace IncidentReport.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetPostedApplicationsHandler : IQueryHandler<GetPostedApplications, IEnumerable<PostedApplicationDto>>
    {
        private readonly IMongoDatabase _database;

        public GetPostedApplicationsHandler(IMongoDatabase database)
        {
            _database = database;
        }
        
        public async Task<IEnumerable<PostedApplicationDto>> HandleAsync(GetPostedApplications query)
        {
            var collection =  _database.GetCollection<PostedApplicationDocument>("posted-applications");
            var allDocuments = await collection.Find(_ => true).ToListAsync();
            return allDocuments.Select(d => d.AsDto());
        }
    }
}