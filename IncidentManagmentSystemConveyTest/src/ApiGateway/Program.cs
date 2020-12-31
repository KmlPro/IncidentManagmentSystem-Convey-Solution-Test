using System.Linq;
using System.Threading.Tasks;
using Convey;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ntrada;

namespace ApiGateway
{
    public class Program
    {
        public static Task Main(string[] args)
            => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(builder =>
                        {
                            var configPath = args?.FirstOrDefault() ?? "ntrada.yml";
                            builder.AddYamlFile(configPath, false);
                        })
                        .ConfigureServices(services => services.AddNtrada()
                            .AddConvey())
                        .Configure(app => app.UseNtrada());
                });
    }
}