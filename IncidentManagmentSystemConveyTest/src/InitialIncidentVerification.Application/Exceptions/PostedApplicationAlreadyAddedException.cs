using System;

namespace InitialIncidentVerification.Application.Exceptions
{
    public class PostedApplicationAlreadyAddedException : AppException
    {
        public override string Code { get; } = "posted_application_already_exists";
        public Guid PostedApplicationId { get; }

        public PostedApplicationAlreadyAddedException(Guid id) : base(
            $"Posted application with id: {id} already exists.")
            => PostedApplicationId = id;
    }
}