using DependencyInjectionMethods.Services.Enums;

namespace DependencyInjectionMethods.Services.Payment
{
    public class MolliePaymentProviderService : IPaymentProviderService
    {
        public PaymentServiceType PaymentServiceType => PaymentServiceType.Mollie;

        public Task DoPayment()
        {
            throw new NotImplementedException();
        }
    }
}
