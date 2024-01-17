using Microsoft.Extensions.Options;

namespace Awesome.HelloWorld;

public interface IHelloWorldMessageService
{
    string GetHelloMessageToTheWorld();
}

public class HelloWorldMessageService(IOptions<HelloWorldOptions> helloWorldOptions) : IHelloWorldMessageService
{
    private readonly HelloWorldOptions _helloWorldOptions = helloWorldOptions.Value ?? throw new ArgumentNullException(nameof(helloWorldOptions));
    private const string HelloMessageToTheWorld = "Hello World!";
    
    public string GetHelloMessageToTheWorld()
    {
        return _helloWorldOptions.Message ?? HelloMessageToTheWorld;
    }
}