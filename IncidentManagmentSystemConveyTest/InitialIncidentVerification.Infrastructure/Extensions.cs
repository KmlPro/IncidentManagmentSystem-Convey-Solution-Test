using System;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.Outbox;
using Convey.MessageBrokers.Outbox.Mongo;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using InitialIncidentVerification.Application.Events.External;
using InitialIncidentVerification.Infrastructure.Decorators;
using InitialIncidentVerification.Infrastructure.Mongo.Documents;
using InitialIncidentVerification.Infrastructure.Mongo.Repositories;
using InitialIncidentVerification.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InitialIncidentVerification.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services
                .AddTransient<IIncidentVerificationApplicationRepository, IncidentVerificationApplicationMongoRepository>();
            builder.Services.TryDecorate(typeof(ICommandHandler<>), typeof(OutboxCommandHandlerDecorator<>));
            builder.Services.TryDecorate(typeof(IEventHandler<>), typeof(OutboxEventHandlerDecorator<>));

            builder.AddMongo()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddMongoRepository<IncidentVerificationApplicationDocument, Guid>("incident-verification-application")
                .AddRabbitMq()
                .AddMessageOutbox(o => o.AddMongo());

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseConvey()
                .UseRabbitMq()
                .SubscribeEvent<PostedApplicationAdded>();

            //  .UseSwaggerDocs(); <-- this doesnt work, dont know why.

            return app;
        }
    }
}