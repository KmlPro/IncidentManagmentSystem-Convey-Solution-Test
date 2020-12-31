using System;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.Outbox;
using Convey.MessageBrokers.Outbox.Mongo;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Convey.WebApi.Swagger;
using IncidentReport.Application;
using IncidentReport.Application.Commands;
using IncidentReport.Application.Events;
using IncidentReport.Application.Services;
using IncidentReport.Core.Repositories;
using IncidentReport.Infrastructure.Decorators;
using IncidentReport.Infrastructure.Exceptions;
using IncidentReport.Infrastructure.Mongo.Documents.DraftApplication;
using IncidentReport.Infrastructure.Mongo.Documents.PostedApplication;
using IncidentReport.Infrastructure.Mongo.Repositories;
using IncidentReport.Infrastructure.Services;
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
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddSingleton<IEventMapper, EventMapper>();
            builder.Services.AddTransient<IEventProcessor, EventProcessor>();
            builder.Services.TryDecorate(typeof(ICommandHandler<>), typeof(OutboxCommandHandlerDecorator<>));
            builder.Services.TryDecorate(typeof(IEventHandler<>), typeof(OutboxEventHandlerDecorator<>));

            builder.Services.Scan(s =>
                s.FromAssemblies((AppDomain.CurrentDomain.GetAssemblies()))
                    .AddClasses(c => c.AssignableTo((typeof(IDomainEventHandler<>)))).AsImplementedInterfaces()
                    .WithTransientLifetime());

            builder.AddMongo()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddMongoRepository<DraftApplicationDocument, Guid>("draft-applications")
                .AddMongoRepository<PostedApplicationDocument, Guid>("posted-applications")
                .AddSwaggerDocs()
                .AddWebApiSwaggerDocs()
                .AddRabbitMq()
                .AddMessageOutbox(o => o.AddMongo());
            
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseConvey()
                .UsePublicContracts<ContractAttribute>() //<-- for /_contracts url
                .UseRabbitMq()
                .SubscribeCommand<PostApplication>(); //<-- async handling commands
           
              //  .UseSwaggerDocs(); <-- this doesnt work, dont know why.
            
            // app.UseRabbitMq()
            //     .SubscribeEvent<SignedUp>();
            return app;
        }
    }
}