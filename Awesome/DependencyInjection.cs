using Awesome.HelloWorld;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Awesome;

internal static class DependencyInjection
{
    internal static IServiceProvider GetServices()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        var services = new ServiceCollection()
            .AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            })

            #region HelloWorld
            .Configure<HelloWorldOptions>(configuration.GetSection(nameof(HelloWorldOptions)))
            .AddScoped<IHelloWorld, HelloWorld.HelloWorld>()
            .AddScoped<IHelloWorldMessageService, HelloWorldMessageService>()
            #endregion

            .BuildServiceProvider();

        return services;
    }
}