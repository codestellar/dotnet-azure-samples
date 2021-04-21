using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Codestellar.HttpClientFactory
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    var commonHandler = new HttpClientHandler();

                    services.AddHttpClient("JsonPlaceHolder", httpClient =>
                    {
                        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                    })
                    .ConfigurePrimaryHttpMessageHandler(() => commonHandler);
                    services.AddHttpClient("ConferenceApi", httpClient =>
                    {
                        httpClient.BaseAddress = new Uri("https://conferenceapi.azurewebsites.net");
                    })
                    .ConfigurePrimaryHttpMessageHandler(() => commonHandler);
                    services.AddScoped<IMyService, MyService>();
                    services.AddScoped<IMyService2, MyService2>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            try
            {
                var myService = host.Services.GetRequiredService<IMyService>();
                var myService2 = host.Services.GetRequiredService<IMyService2>();
                //do
                //{
                //    while (!Console.KeyAvailable)
                //    {
                //        // Do something

                //    }
                //} while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Console.WriteLine("\n\nChecking Handle Count\n\n");
                Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().HandleCount);

                for (var i = 0; i < 100; i++)
                {
                    var pageContent = await myService.GetPage();

                    Console.WriteLine(pageContent.Substring(0, 500));

                    Console.WriteLine("\n\n\n###########################################################\n\n");


                    var pageContent2 = await myService2.GetName();

                    Console.WriteLine(pageContent2.Substring(0, 500));

                }
                Console.WriteLine("\n\nChecking Handle Count\n\n");
                Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().HandleCount);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred.");
                Console.ReadKey();
            }

            return 0;
        }
    }

    public interface IMyService
    {
        Task<string> GetPage();
    }

    public interface IMyService2
    {
        Task<string> GetName();
    }

    public class MyService : IMyService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MyService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetPage()
        {
            using var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"/posts");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }
    }

    public class MyService2 : IMyService2
    {
        private readonly IHttpClientFactory _clientFactory;

        public MyService2(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetName()
        {
            var client = _clientFactory.CreateClient("ConferenceApi");
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"/speakers");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }
    }
}
