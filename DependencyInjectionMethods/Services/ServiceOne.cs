namespace DependencyInjectionMethods.Services;

public class ServiceOne : IService, IServiceSingleton, IServiceScoped, IServiceTransient
{
    public void DoSomething()
    {
        throw new NotImplementedException();
    }
}
