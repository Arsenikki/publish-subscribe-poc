using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Subi.Configuration;
using Subi.Consumers;

namespace Subi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var massTransitConfig = hostContext.Configuration.GetSection("MassTransit").Get<MassTransitConfig>();
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();
                        x.AddConsumer<WorkConsumer>(typeof(WorkConsumerDefinition));
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(massTransitConfig.Host, "/", h =>
                            {
                                h.Username(massTransitConfig.Username);
                                h.Password(massTransitConfig.Password);
                            });
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                });
    }
}
