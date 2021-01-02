using System.Threading.Tasks;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;
using IncidentReport.Application.Queries;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using IncidentReport.Infrastructure.Mongo.Documents.PostedApplication;
using MongoDB.Driver;

namespace IncidentReport.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetPostedApplicationHandler : IQueryHandler<GetPostedApplication, PostedApplicationDto>
    {
        private readonly IMongoDatabase _database;

        public GetPostedApplicationHandler(IMongoDatabase database)
        {
            _database = database;
        }
        
        public async Task<PostedApplicationDto> HandleAsync(GetPostedApplication query)
        {
            var document = await _database.GetCollection<PostedApplicationDocument>("posted-applications")
                .Find(x => x.Id == query.PostedApplicationId)
                .SingleOrDefaultAsync();

            return document?.AsDto();
        }
    }
}