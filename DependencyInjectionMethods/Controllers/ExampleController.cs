using DependencyInjectionMethods.Services;
using DependencyInjectionMethods.Services.Delegates;
using DependencyInjectionMethods.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionMethods.Controllers;

[ApiController]
public class ExampleController : ControllerBase
{
    //private readonly IService _service;
    //private readonly IEnumerable<IService> _services;
    //private readonly IServiceSingleton _serviceSingleton;
    //private readonly IServiceScoped _serviceScoped;
    //private readonly IServiceTransient _serviceTransient;
    private readonly ServiceResolver _serviceResolver;

    public ExampleController(ServiceResolver serviceResolver)
        //IService service, IEnumerable<IService> services, IServiceSingleton serviceSingleton, IServiceScoped serviceScoped, IServiceTransient serviceTransient)
    {
        //_service = service;
        //_services = services;
        //_serviceSingleton = serviceSingleton;
        //_serviceScoped = serviceScoped;
        //_serviceTransient = serviceTransient;
        _serviceResolver = serviceResolver;
    }

//    [HttpGet("servicelifetime")]
//    public IActionResult ServiceLifetime()
//    {
//        var value = $@"Service: {_service.GetType().Name}, ";
////Singleton: {_serviceSingleton.GetType().Name}, 
////Scoped: {_serviceScoped.GetType().Name}, 
////Transient: {_serviceTransient.GetType().Name}";

//        return Ok(value);
//    }

//    [HttpGet("singleservice")]
//    public IActionResult SingleService()
//    {
//        return Ok(_service.GetType().Name);
//    }

//    [HttpGet("multipleservices")]
//    public IActionResult MultipleServices()
//    {
//        return Ok(_services.Select(x => x.GetType().Name));
//    }

    [HttpGet("ServiceOne")]
    public IActionResult ServiceOne()
    {
        var service = _serviceResolver(ServiceType.ServiceOne);

        return Ok(service.GetType().Name);
    }

    [HttpGet("ServiceTwo")]
    public IActionResult ServiceTwo()
    {
        var service = _serviceResolver(ServiceType.ServiceTwo);

        return Ok(service.GetType().Name);
    }
}
