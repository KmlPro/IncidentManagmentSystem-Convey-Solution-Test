using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;

namespace IncidentReport.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.AddMongo();
            
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}