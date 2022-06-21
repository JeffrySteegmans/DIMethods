namespace DependencyInjectionMethods.Services;

public interface IService
{
    void DoSomething();
}
public interface IServiceSingleton : IService {}
public interface IServiceScoped : IService {}
public interface IServiceTransient : IService {}