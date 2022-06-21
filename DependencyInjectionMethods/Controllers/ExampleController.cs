using DependencyInjectionMethods.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionMethods.Controllers;

[ApiController]
public class ExampleController : ControllerBase
{
    private readonly IService _service;
    private readonly IEnumerable<IService> _services;
    private readonly IServiceSingleton _serviceSingleton;
    private readonly IServiceScoped _serviceScoped;
    private readonly IServiceTransient _serviceTransient;

    public ExampleController(IService service, IEnumerable<IService> services, IServiceSingleton serviceSingleton, 
        IServiceScoped serviceScoped, IServiceTransient serviceTransient)
    {
        _service = service;
        _services = services;
        _serviceSingleton = serviceSingleton;
        _serviceScoped = serviceScoped;
        _serviceTransient = serviceTransient;
    }

    [HttpGet("servicelifetime")]
    public IActionResult ServiceLifetime()
    {
        var value = $@"Service: {_service.GetType().Name}, 
Singleton: {_serviceSingleton.GetType().Name}, 
Scoped: {_serviceScoped.GetType().Name}, 
Transient: {_serviceTransient.GetType().Name}";

        return Ok(value);
    }

    [HttpGet("singleservice")]
    public IActionResult SingleService()
    {
        return Ok(_service.GetType().Name);
    }

    [HttpGet("multipleservices")]
    public IActionResult MultipleServices()
    {
        return Ok(_services.Select(x => x.GetType().Name));
    }

    
}
