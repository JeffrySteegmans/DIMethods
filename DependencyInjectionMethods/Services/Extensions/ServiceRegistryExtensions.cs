using DependencyInjectionMethods.Services.Delegates;
using DependencyInjectionMethods.Services.Enums;
using DependencyInjectionMethods.Services.Payment;
using DependencyInjectionMethods.Services.ServiceResolvers;
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
                
        public static IServiceCollection TryAddServiceOneWitMultipleLifeTimes(this IServiceCollection services)
        {
            services.TryAddSingleton<IService, ServiceOne>();
            services.TryAddScoped<IService, ServiceOne>();
            services.TryAddTransient<IService, ServiceOne>();

            return services;
        }
                
        public static IServiceCollection TryAddEnumerableServiceOneWitMultipleLifeTimes(this IServiceCollection services)
        {
            var serviceDescriptorSingleton = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Singleton);
            var serviceDescriptorScoped = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Scoped);
            var serviceDescriptorTransient = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Transient);

            services.TryAddEnumerable(new List<ServiceDescriptor> { serviceDescriptorScoped, serviceDescriptorSingleton, serviceDescriptorTransient });

            return services;
        }

        public static IServiceCollection TryAddServiceOneWitMultipleLifeTimesAndTokenInterface(this IServiceCollection services)
        {
            services.TryAddSingleton<IService, ServiceOne>();
            services.TryAddSingleton<IServiceSingleton, ServiceOne>();
            services.TryAddScoped<IServiceScoped, ServiceOne>();
            services.TryAddTransient<IServiceTransient, ServiceOne>();

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

        public static IServiceCollection TryAddReadWriteServicesAsSingleton(this IServiceCollection services)
        {
            services.TryAddSingleton<ReadWriteService>();
            services.TryAddSingleton<IRead>(x => x.GetRequiredService<ReadWriteService>());
            services.TryAddSingleton<IWrite>(x => x.GetRequiredService<ReadWriteService>());

            return services;
        }

        public static IServiceCollection AddServiceResolver(this IServiceCollection services)
        {
            services.AddScoped<ServiceOne>();
            services.AddScoped<ServiceTwo>();

            services.AddTransient<ServiceResolver>(serviceProvider => serviceType => serviceType switch
            {
                ServiceType.ServiceTwo => serviceProvider.GetService<ServiceTwo>()!,
                _ => serviceProvider.GetService<ServiceOne>()!
            });


            return services;
        }

        public static IServiceCollection AddPaymentServiceResolver(this IServiceCollection services)
        {
            services.AddScoped<MolliePaymentProviderService>();
            services.AddScoped<CCVPaymentProviderService>();
            services.AddScoped<NetsPaymentProviderService>();

            services.AddTransient<PaymentServiceResolver>(serviceProvider => paymentServiceType => paymentServiceType switch
            {
                PaymentServiceType.Mollie => serviceProvider.GetService<MolliePaymentProviderService>()!,
                PaymentServiceType.NETS => serviceProvider.GetService<NetsPaymentProviderService>()!,
                _ => serviceProvider.GetService<CCVPaymentProviderService>()!
            });

            return services;
        }

        public static IServiceCollection AddPaymentServices(this IServiceCollection services)
        {
            services.AddSingleton<IPaymentProviderService, MolliePaymentProviderService>();
            services.AddSingleton<IPaymentProviderService, CCVPaymentProviderService>();
            services.AddSingleton<IPaymentProviderService, NetsPaymentProviderService>();

            return services;
        }
    }
}
