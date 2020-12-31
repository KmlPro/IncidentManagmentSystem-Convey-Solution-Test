using System;
using System.Collections.Generic;
using Convey.Logging.CQRS;
using InitialIncidentVerification.Application.Events.External;
using InitialIncidentVerification.Application.Exceptions;

namespace InitialIncidentVerification.Infrastructure.Logging
{
    internal sealed class MessageToLogTemplateMapper : IMessageToLogTemplateMapper
    {
        private static IReadOnlyDictionary<Type, HandlerLogTemplate> MessageTemplates 
            => new Dictionary<Type, HandlerLogTemplate>
            {
                {
                    typeof(PostedApplicationAdded),     
                    new HandlerLogTemplate
                    {
                        After = "Added a posted application with id: {PostedApplicationId}",
                        OnError = new Dictionary<Type, string>
                        {
                            {
                                typeof(PostedApplicationAlreadyAddedException), 
                                "Posted application with id: {PostedApplicationId} was already added."
                            }
                        }
                    }
                },
            };
        
        public HandlerLogTemplate Map<TMessage>(TMessage message) where TMessage : class
        {
            var key = message.GetType();
            return MessageTemplates.TryGetValue(key, out var template) ? template : null;
        }
    }
}