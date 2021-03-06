using System;
using IncidentReport.Application.DTO;

namespace IncidentReport.Infrastructure.Mongo.Documents.PostedApplication
{
    internal static class Extensions
    {
        public static Core.Entities.PostedApplication AsEntity(this PostedApplicationDocument document) =>
            new Core.Entities.PostedApplication(document.Id, document.Content, document.Title,
                document.DateCreated.AsDateTime(),
                document.Version);

        public static PostedApplicationDocument AsDocument(this Core.Entities.PostedApplication draftApplication) =>
            new PostedApplicationDocument()
            {
                Id = draftApplication.Id,
                Version = draftApplication.Version,
                Content = draftApplication.Content,
                Title = draftApplication.Title,
                DateCreated = draftApplication.DateCreated.AsDaysSinceEpoch(),
            };

        public static PostedApplicationDto AsDto(this PostedApplicationDocument document) =>
            new PostedApplicationDto()
            {
                Id = document.Id,
                Version = document.Version,
                Content = document.Content,
                Title = document.Title,
                DateCreated = document.DateCreated.AsDateTime()
            };

        internal static int AsDaysSinceEpoch(this DateTime dateTime) => (dateTime - new DateTime()).Days;

        internal static DateTime AsDateTime(this int daysSinceEpoch) => new DateTime().AddDays(daysSinceEpoch);
    }
}