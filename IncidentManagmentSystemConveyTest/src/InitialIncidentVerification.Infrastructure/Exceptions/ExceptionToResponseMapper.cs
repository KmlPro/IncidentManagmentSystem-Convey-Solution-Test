using System;
using System.Net;
using Convey.WebApi.Exceptions;
using InitialIncidentVerification.Application.Exceptions;
using InitialIncidentVerification.Exceptions;

namespace InitialIncidentVerification.Infrastructure.Exceptions
{
    internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "There was an error on server side"},
                    HttpStatusCode.InternalServerError)
            };
    }
}