using System;

namespace IncidentReport.Application.Exceptions
{
    public class DraftApplicationNotFoundException : AppException
    {
        public override string Code { get; } = "draft_application_not_found";
        public Guid Id { get; }

        public DraftApplicationNotFoundException(Guid id) : base($"Draft application with id: {id} not found.")
            => Id = id;
    }
}