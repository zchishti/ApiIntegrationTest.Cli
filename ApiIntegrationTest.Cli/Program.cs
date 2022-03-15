using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Http;
using System.Net.Http.Headers;
using ApiIntegrationTest.Cli.API;
using System.Threading.Tasks;
using System.Text.Json;
using ApiIntegrationTest.Cli.Output;
using ApiIntegrationTest.Cli.Services;

namespace ApiIntegrationTest.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration();
            var serviceProvider = BuildServiceProvider(configuration);

            var app = serviceProvider.GetRequiredService<TaxJarApplication>();
            
            await app.RunAsync(args);

            /*            var client = serviceProvider.GetService<ITaxApi>();

                        var response = await client.SearchByZipCodeAsync("73034");

                        var responseText = JsonSerializer.Serialize(response, new JsonSerializerOptions { 
                            WriteIndented = true
                        });

                        Console.WriteLine(responseText); */
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                                                .AddJsonFile("appsettings.json")
                                                .Build();
            return configuration;
        }

        private static ServiceProvider BuildServiceProvider(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            ConfigureServices(configuration, services);
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(IConfigurationRoot configuration, IServiceCollection services)
        {
            services.AddSingleton<TaxJarApplication>();
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddSingleton<ITaxRateSearchService, TaxRateSearchService>();
            services.AddHttpClient<ITaxApi, TaxAPI>("TaxJar", client =>
            {
                client.BaseAddress = new Uri(configuration["TaxAPI:BaseAddress"]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["TaxAPI:API_KEY"]);
            });
        }
    }
}
