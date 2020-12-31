using Convey;
using Convey.Logging.CQRS;
using InitialIncidentVerification.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace InitialIncidentVerification.Infrastructure.Logging
{
    internal static class Extensions
    {
        public static IConveyBuilder AddHandlersLogging(this IConveyBuilder builder)
        {
            var assembly = typeof(AppException).Assembly;
            
            builder.Services.AddSingleton<IMessageToLogTemplateMapper>(new MessageToLogTemplateMapper());
            
            return builder
                .AddCommandHandlersLogging(assembly)
                .AddEventHandlersLogging(assembly);
        }
    }
}