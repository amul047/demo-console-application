using Awesome;
using Awesome.HelloWorld;
using Microsoft.Extensions.DependencyInjection;

var services = DependencyInjection.GetServices();

services.GetService<IHelloWorld>()?.SayHelloToTheWorld();
