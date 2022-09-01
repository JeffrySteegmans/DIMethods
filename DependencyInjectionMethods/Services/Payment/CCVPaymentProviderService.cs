using DependencyInjectionMethods.Services.Enums;

namespace DependencyInjectionMethods.Services.Payment
{
    public class CCVPaymentProviderService : IPaymentProviderService
    {
        public PaymentServiceType PaymentServiceType => PaymentServiceType.CCV;

        public Task DoPayment()
        {
            throw new NotImplementedException();
        }
    }
}
