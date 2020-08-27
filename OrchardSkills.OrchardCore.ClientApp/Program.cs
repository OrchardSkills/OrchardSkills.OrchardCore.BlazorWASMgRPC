using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrchardSkills.OrchardCore.ClientApp.Pages;

namespace OrchardSkills.OrchardCore.ClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var serverUrl = config["ServerUrl"];

                var channel = GrpcChannel.ForAddress(serverUrl, new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())
                });

                var client = new Classes.ClassesClient(channel);
                return client;
            });

            // builder.RootComponents.Add<Counter>("my-counter");

            // builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
