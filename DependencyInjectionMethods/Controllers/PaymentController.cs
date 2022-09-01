using DependencyInjectionMethods.Services.Enums;
using DependencyInjectionMethods.Services.Payment;
using DependencyInjectionMethods.Services.ServiceResolvers;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionMethods.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentProviderServicesResolver _paymentProviderServicesResolver;

        public PaymentController(PaymentProviderServicesResolver paymentProviderServicesResolver)
        {
            _paymentProviderServicesResolver = paymentProviderServicesResolver;
        }

        [HttpGet("paymentproviderserviceresolver/{serviceType}")]
        public IActionResult GetByPaymentProviderServiceResolver(string serviceType)
        {
            var type = (PaymentServiceType)Enum.Parse(typeof(PaymentServiceType), serviceType, true);

            var service = _paymentProviderServicesResolver.GetService(type);

            return Ok(service.GetType().Name);
        }
    }
}
