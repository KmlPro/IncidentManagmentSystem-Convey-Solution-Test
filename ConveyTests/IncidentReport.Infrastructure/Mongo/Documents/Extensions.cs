using System;
using IncidentReport.Application.DTO;
using IncidentReport.Core.Entities;

namespace IncidentReport.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static DraftApplication AsEntity(this DraftApplicationDocument document) =>
            new DraftApplication(document.Id, document.Content, document.Title, document.DateCreated.AsDateTime(),
                document.Version);

        public static DraftApplicationDocument AsDocument(this DraftApplication draftApplication) =>
            new DraftApplicationDocument()
            {
                Id = draftApplication.Id,
                Version = draftApplication.Version,
                Content = draftApplication.Content,
                Title = draftApplication.Title,
                DateCreated = draftApplication.DateCreated.AsDaysSinceEpoch()
            };

        public static DraftApplicationDto AsDto(this DraftApplicationDocument document) =>
            new DraftApplicationDto()
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