using System.Collections.Generic;
using System.Threading.Tasks;
using Convey;
using Convey.Types;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using IncidentReport.Application;
using IncidentReport.Application.Commands;
using IncidentReport.Application.DTO;
using IncidentReport.Application.Queries;
using IncidentReport.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentReport
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseRouting()
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync(
                            ctx.RequestServices.GetService<AppOptions>().Name))
                        .Get<GetDraftApplications, IEnumerable<DraftApplicationDto>>("draft-application") 
                        .Get<GetDraftApplication, DraftApplicationDto>("draft-application/{draftApplicationId}") 
                        .Post<CreateDraftApplication>("draft-application", 
                            afterDispatch: (cmd, ctx) => ctx.Response.Created($"draft-application/{cmd.Id}"))
                        .Post<MarkAsReadyToPost>("draft-application/{draftApplicationId}/mark-as-ready-for-post", afterDispatch: (cmd, ctx) => ctx.Response.NoContent())
                        .Post<PostApplication>("posted-application", 
                            afterDispatch: (cmd, ctx) => ctx.Response.Created($"posted-application/{cmd.Id}"))
                    ));
    }
}