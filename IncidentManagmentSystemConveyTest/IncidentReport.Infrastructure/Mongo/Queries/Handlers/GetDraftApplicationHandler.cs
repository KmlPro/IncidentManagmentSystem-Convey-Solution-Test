using System.Threading.Tasks;
using Convey.CQRS.Queries;
using IncidentReport.Application.DTO;
using IncidentReport.Application.Queries;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using MongoDB.Driver;

namespace IncidentReport.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetDraftApplicationHandler : IQueryHandler<GetDraftApplication, DraftApplicationDto>
    {
        private readonly IMongoDatabase _database;

        public GetDraftApplicationHandler(IMongoDatabase database)
        {
            _database = database;
        }
        
        public async Task<DraftApplicationDto> HandleAsync(GetDraftApplication query)
        {
            var document = await _database.GetCollection<DraftApplicationDocument>("draft-applications")
                .Find(x => x.Id == query.DraftApplicationId)
                .SingleOrDefaultAsync();

            return document?.AsDto();
        }
    }
}