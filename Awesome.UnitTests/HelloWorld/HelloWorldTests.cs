using Awesome.HelloWorld;
using Microsoft.Extensions.Options;
using Moq;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Awesome.UnitTests.HelloWorld;

public class HelloWorldTests
{
    private IHelloWorldMessageService _helloWorldMessageService;
    private readonly Mock<IOptions<HelloWorldOptions>> _helloWorldOptions = new();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HelloWorld_SaysStandardHelloWorld_WhenSayHelloToTheWorld_IsCalled_WithoutSettings()
    {
        // Arrange
        var expectedMessage = "Hello World!";
        _helloWorldOptions.SetupGet(o => o.Value)
            .Returns(new HelloWorldOptions());
        _helloWorldMessageService = new HelloWorldMessageService(_helloWorldOptions.Object);

        // Act
        var helloMessageToTheWorld = _helloWorldMessageService.GetHelloMessageToTheWorld();

        //Assert
        Assert.That(expectedMessage, Is.EqualTo(helloMessageToTheWorld));
    }

    [Test]
    public void HelloWorld_SaysStandardHelloWorld_WhenSayHelloToTheWorld_IsCalled_WithSettings()
    {
        // Arrange
        var expectedMessage = "Hello Earth!";
        _helloWorldOptions.SetupGet(o => o.Value)
            .Returns(new HelloWorldOptions { Message = "Hello Earth!" });
        _helloWorldMessageService = new HelloWorldMessageService(_helloWorldOptions.Object);

        // Act
        var helloMessageToTheWorld = _helloWorldMessageService.GetHelloMessageToTheWorld();

        //Assert
        Assert.That(helloMessageToTheWorld, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void HelloWorld_SaysStandardHelloWorld_WhenSayHelloToTheWorld_IsCalled_WithSettingsAndName()
    {
        // Arrange
        var expectedMessage = "Hello Earth!";
        _helloWorldOptions.SetupGet(o => o.Value)
            .Returns(new HelloWorldOptions { Message = "Hello Earth!" });
        _helloWorldMessageService = new HelloWorldMessageService(_helloWorldOptions.Object);

        // Act
        var helloMessageToTheWorld = _helloWorldMessageService.GetHelloMessageToTheWorld();

        //Assert
        Assert.That(helloMessageToTheWorld, Is.EqualTo(expectedMessage));
    }
}