using DependencyInjectionMethods.Services.Enums;

namespace DependencyInjectionMethods.Services.Payment;

public interface IPaymentProviderService
{
    public PaymentServiceType PaymentServiceType { get; }

    public Task DoPayment();
}
