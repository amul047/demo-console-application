using Microsoft.Extensions.Logging;

namespace Awesome.HelloWorld;

/// <summary>
/// "Class"ic Hello World
/// </summary>
public interface IHelloWorld
{
    /// <summary>
    /// Say hello to the world.
    /// </summary>
    void SayHelloToTheWorld();
}

public class HelloWorld(ILoggerFactory loggerFactory, IHelloWorldMessageService helloWorldMessageService) : IHelloWorld
{
    private readonly ILogger<HelloWorld> _logger = loggerFactory.CreateLogger<HelloWorld>();

    public void SayHelloToTheWorld()
    {
        var message = helloWorldMessageService.GetHelloMessageToTheWorld();
        _logger.LogInformation($"The Hello world message is \"{message}\".", message);
        Console.WriteLine(message);
    }
}