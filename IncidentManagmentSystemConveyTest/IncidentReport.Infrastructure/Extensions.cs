using System;
using Convey;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using IncidentReport.Application.Events.External;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Exceptions;
using IncidentReport.Infrastructure.Mongo.Documents;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using IncidentReport.Infrastructure.Mongo.Documents.PostedApplication;
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
            builder.Services.AddTransient<IPostedApplicationRepository, PostedApplicationMongoRepository>();

            builder.AddMongo()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddMongoRepository<DraftApplicationDocument, Guid>("draft-applications")
                .AddMongoRepository<PostedApplicationDocument, Guid>("posted-applications");
             //   .AddRabbitMq();
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler();
            // app.UseRabbitMq()
            //     .SubscribeEvent<SignedUp>();
            return app;
        }
    }
}