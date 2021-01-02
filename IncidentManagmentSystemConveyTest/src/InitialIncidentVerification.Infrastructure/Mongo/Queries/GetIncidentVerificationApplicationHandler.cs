using System.Threading.Tasks;
using Convey.CQRS.Queries;
using InitialIncidentVerification.Application.DTO;
using InitialIncidentVerification.Application.Queries;
using InitialIncidentVerification.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace InitialIncidentVerification.Infrastructure.Mongo.Queries
{
    public class GetIncidentVerificationApplicationHandler : IQueryHandler<GetIncidentVerificationApplication, IncidentVerificationApplicationDto>
    {
        private readonly IMongoDatabase _database;

        public GetIncidentVerificationApplicationHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IncidentVerificationApplicationDto> HandleAsync(GetIncidentVerificationApplication query)
        {
            var document = await _database.GetCollection<IncidentVerificationApplicationDocument>("incident-verification-applications")
                .Find(x => x.Id == query.IncidentVerificationApplicationId)
                .SingleOrDefaultAsync();

            return document?.AsDto();
        }
    }
}