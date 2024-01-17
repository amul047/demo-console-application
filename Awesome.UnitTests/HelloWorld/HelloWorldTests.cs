using Awesome.HelloWorld;
using Microsoft.Extensions.Options;
using Moq;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Awesome.UnitTests.HelloWorld;

public class HelloWorldTests
{
    private IHelloWorldMessageService _helloWorldMessageService;

    [SetUp]
    public void Setup()
    {
        var helloWorldOptions = new Mock<IOptions<HelloWorldOptions>>();
        _helloWorldMessageService = new HelloWorldMessageService(helloWorldOptions.Object);
    }

    [Test]
    public void HelloWorld_SaysStandardHelloWorld_WhenSayHelloToTheWorld_IsCalled()
    {
        // Arrange
        var expectedMessage = "Hello World!";
        
        // Act
        var helloMessageToTheWorld = _helloWorldMessageService.GetHelloMessageToTheWorld();

        //Assert
        Assert.Equals(helloMessageToTheWorld, expectedMessage);
    }
}