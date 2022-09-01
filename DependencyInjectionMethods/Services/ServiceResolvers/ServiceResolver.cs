using DependencyInjectionMethods.Services.Enums;

namespace DependencyInjectionMethods.Services.Delegates;

public delegate IService ServiceResolver(ServiceType serviceType);