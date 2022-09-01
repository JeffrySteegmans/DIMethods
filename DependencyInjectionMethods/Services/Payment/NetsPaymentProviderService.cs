using DependencyInjectionMethods.Services.Enums;

namespace DependencyInjectionMethods.Services.Payment
{
    public class NetsPaymentProviderService : IPaymentProviderService
    {
        public PaymentServiceType PaymentServiceType => PaymentServiceType.NETS;

        public Task DoPayment()
        {
            throw new NotImplementedException();
        }
    }
}
