using System;
using Convey;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Convey.WebApi.Swagger;
using IncidentReport.Application;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Exceptions;
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
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddMongoRepository<DraftApplicationDocument, Guid>("draft-applications")
                .AddMongoRepository<PostedApplicationDocument, Guid>("posted-applications")
                .AddSwaggerDocs()
                .AddWebApiSwaggerDocs();
            //   .AddRabbitMq();
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseConvey()
                .UsePublicContracts<ContractAttribute>();
              //  .UseSwaggerDocs(); <-- this doesnt work, dont know why.
            
            // app.UseRabbitMq()
            //     .SubscribeEvent<SignedUp>();
            return app;
        }
    }
}