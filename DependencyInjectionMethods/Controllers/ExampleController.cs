using DependencyInjectionMethods.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionMethods.Controllers;

[ApiController]
public class ExampleController : ControllerBase
{
    private readonly IService _service;
    private readonly IEnumerable<IService> _services;

    public ExampleController(IService service, IEnumerable<IService> services)
    {
        _service = service;
        _services = services;
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
