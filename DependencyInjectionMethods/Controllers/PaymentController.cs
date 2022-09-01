using DependencyInjectionMethods.Services.Enums;
using DependencyInjectionMethods.Services.Payment;
using DependencyInjectionMethods.Services.ServiceResolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionMethods.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentServiceResolver _serviceResolver;
        private readonly IEnumerable<IPaymentProviderService> _paymentProviderServices;

        public PaymentController(PaymentServiceResolver serviceResolver, IEnumerable<IPaymentProviderService> paymentProviderServices)
        {
            _serviceResolver = serviceResolver;
            _paymentProviderServices = paymentProviderServices;
        }

        [HttpGet("serviceresolver/{serviceType}")]
        public IActionResult GetByServiceResolver(string serviceType)
        {
            var type = (PaymentServiceType)Enum.Parse(typeof(PaymentServiceType), serviceType, true);

            var service = _serviceResolver(type);

            return Ok(service.GetType().Name);
        }

        [HttpGet("reflection/{serviceName}")]
        public IActionResult CCVByReflection(string serviceName)
        {
            var paymentProviderService = _paymentProviderServices.FirstOrDefault(x => x.GetType().Name.ToLower() == $"{serviceName}paymentproviderservice");

            return Ok(paymentProviderService!.GetType().Name);
        }
    }
}
