using System;

namespace IncidentReport.Application.Exceptions
{
    public class DraftApplicationAlreadyExistsException : AppException
    {
        public override string Code { get; } = "draft_application_already_exists";
        public Guid Id { get; }

        public DraftApplicationAlreadyExistsException(Guid id) : base($"Draft application with id: {id} already exists.")
            => Id = id;
    }
}