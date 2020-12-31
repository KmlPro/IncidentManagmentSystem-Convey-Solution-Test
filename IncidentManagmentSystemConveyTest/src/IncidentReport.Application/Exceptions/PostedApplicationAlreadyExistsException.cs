using System;

namespace IncidentReport.Application.Exceptions
{
    public class PostedApplicationAlreadyExistsException : AppException
    {
        public override string Code { get; } = "posted_application_already_exists";
        public Guid PostedApplicationId { get; }

        public PostedApplicationAlreadyExistsException(Guid id) : base($"Posted application with id: {id} already exists.")
            => PostedApplicationId = id;
    }
}