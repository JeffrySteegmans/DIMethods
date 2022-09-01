using DependencyInjectionMethods.Services.Enums;
using DependencyInjectionMethods.Services.Payment;

namespace DependencyInjectionMethods.Services.ServiceResolvers
{
    public class PaymentProviderServicesResolver
    {
        private readonly IEnumerable<IPaymentProviderService> _paymentProviderServices;

        public PaymentProviderServicesResolver(IEnumerable<IPaymentProviderService> paymentProviderServices)
        {
            _paymentProviderServices = paymentProviderServices;
        }

        public IPaymentProviderService GetService(PaymentServiceType paymentServiceType) => _paymentProviderServices.Single(x => x.PaymentServiceType == paymentServiceType);
    }
}
