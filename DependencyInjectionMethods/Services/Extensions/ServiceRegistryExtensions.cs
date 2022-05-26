using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyInjectionMethods.Services.Extensions
{
    public static class ServiceRegistryExtensions
    {
        public static IServiceCollection AddServiceOne(this IServiceCollection services)
        {
            return services
                .AddSingleton<IService, ServiceOne>();
        }

        public static IServiceCollection AddServiceTwo(this IServiceCollection services)
        {
            return services
                .AddSingleton<IService, ServiceTwo>();
        }
        
        public static IServiceCollection AddDummyService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IService, ServiceOne>();
        }

        public static IServiceCollection TryAddServiceOne(this IServiceCollection services)
        {
            services.TryAddSingleton<IService, ServiceOne>();

            return services;
        }

        public static IServiceCollection TryAddServiceTwo(this IServiceCollection services)
        {
            services.TryAddSingleton<IService, ServiceTwo>();

            return services;
        }

        public static IServiceCollection TryAddDummyService(this IServiceCollection services)
        {
            services.TryAddSingleton<IService, ServiceOne>();

            return services;
        }
               
        public static IServiceCollection TryAddEnumerableServiceOne(this IServiceCollection services)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Singleton);

            services.TryAddEnumerable(serviceDescriptor);

            return services;
        }

        public static IServiceCollection TryAddEnumerableServiceTwo(this IServiceCollection services)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(IService), typeof(ServiceTwo), ServiceLifetime.Singleton);

            services.TryAddEnumerable(serviceDescriptor);

            return services;
        }

        public static IServiceCollection TryAddEnumerableDummyService(this IServiceCollection services)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Singleton);

            services.TryAddEnumerable(serviceDescriptor);

            return services;
        }
    }
}
