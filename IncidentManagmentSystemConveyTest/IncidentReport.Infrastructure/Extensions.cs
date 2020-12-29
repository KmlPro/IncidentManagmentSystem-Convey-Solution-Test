using System;
using Convey;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Exceptions;
using IncidentReport.Infrastructure.Mongo.Documents;
using IncidentReport.Infrastructure.Mongo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentReport.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IDraftApplicationRepository, DraftApplicationMongoRepository>();
            
            builder.AddMongo()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddMongoRepository<DraftApplicationDocument, Guid>("draft-applications");
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler();
            return app;
        }
    }
}