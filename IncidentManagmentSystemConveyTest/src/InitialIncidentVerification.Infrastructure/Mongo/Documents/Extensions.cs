using System;
using InitialIncidentVerification.Application.DTO;
using InitialIncidentVerification.Entities;

namespace InitialIncidentVerification.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static IncidentVerificationApplication AsEntity(this IncidentVerificationApplicationDocument document) =>
            new IncidentVerificationApplication(document.Id, document.Content, document.Title, document.DateReceived.AsDateTime(),
                document.Version);

        public static IncidentVerificationApplicationDocument AsDocument(this IncidentVerificationApplication application) =>
            new IncidentVerificationApplicationDocument()
            {
                Id = application.Id,
                Version = application.Version,
                Content = application.Content,
                Title = application.Title,
                DateReceived = application.DateReceived.AsDaysSinceEpoch(),
            };
        
        public static IncidentVerificationApplicationDto AsDto(this IncidentVerificationApplicationDocument document) =>
            new IncidentVerificationApplicationDto()
            {
                Id = document.Id,
                Version = document.Version,
                Content = document.Content,
                Title = document.Title,
                DateReceived = document.DateReceived.AsDateTime()
            };

        internal static int AsDaysSinceEpoch(this DateTime dateTime) => (dateTime - new DateTime()).Days;

        internal static DateTime AsDateTime(this int daysSinceEpoch) => new DateTime().AddDays(daysSinceEpoch);
    }
}