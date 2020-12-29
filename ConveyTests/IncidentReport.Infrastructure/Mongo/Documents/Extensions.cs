using System;
using IncidentReport.Core.Entities;

namespace IncidentReport.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static DraftApplication AsEntity(this DraftApplicationDocument document) =>
            new DraftApplication(document.Id, document.Content, document.Title, document.DateCreated.AsDateTime(), document.Version);

        internal static int AsDaysSinceEpoch(this DateTime dateTime) => (dateTime - new DateTime()).Days;
        
        internal static DateTime AsDateTime(this int daysSinceEpoch) => new DateTime().AddDays(daysSinceEpoch);
    }
}