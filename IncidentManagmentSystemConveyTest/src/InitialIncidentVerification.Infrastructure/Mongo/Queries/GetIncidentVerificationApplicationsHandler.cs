using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using InitialIncidentVerification.Application.DTO;
using InitialIncidentVerification.Application.Queries;
using InitialIncidentVerification.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace InitialIncidentVerification.Infrastructure.Mongo.Queries
{
    public class GetIncidentVerificationApplicationsHandler : IQueryHandler<GetIncidentVerificationApplications, IEnumerable<IncidentVerificationApplicationDto>>
    {
        private readonly IMongoDatabase _database;

        public GetIncidentVerificationApplicationsHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<IncidentVerificationApplicationDto>> HandleAsync(GetIncidentVerificationApplications query)
        {
            var collection =
                _database.GetCollection<IncidentVerificationApplicationDocument>("incident-verification-applications");
            
            var allDocuments = await collection.Find(_ => true).ToListAsync();
            return allDocuments.Select(d => d.AsDto());
        }
    }
}