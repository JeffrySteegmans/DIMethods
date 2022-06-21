using DependencyInjectionMethods.Services;
using DependencyInjectionMethods.Services.Extensions;
using FluentAssertions;
using Xunit;

namespace DependencyInjectionMethods.Tests
{
    public class InterfaceSegregationTests
    {
        [Fact]
        public void InterfaceSegregation()
        {
            IServiceCollection services = new ServiceCollection();
            services.TryAddReadWriteServicesAsSingleton();

            using var sp = services.BuildServiceProvider();

            var readInstance = sp.GetRequiredService<IRead>();
            var writeInstance = sp.GetRequiredService<IWrite>();

            // verify the same singleton is used for both (segregated) interfaces
            readInstance.Should().BeSameAs(writeInstance);
        }
    }
}
