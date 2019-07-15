using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Newteq.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// This method adds the service implementation to the service collection - if it does not already exist.
        /// The service is registed as a Singleton Instance
        /// </summary>
        /// <typeparam name="TService">The interface type of the service that you want to register</typeparam>
        /// <typeparam name="TImplementation">The implementation of the type that you want the DI to inject when the TService type is used</typeparam>
        /// <param name="services">The services collection</param>
        public static void TryAddSingleton<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.TryAddMulti<TService, TImplementation>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// This method adds the service implementation to the service collection - if it does not already exist
        /// The service is registed as a Singleton Instance
        /// </summary>
        /// <typeparam name="TService">The interface type of the service that you want to register</typeparam>
        /// <typeparam name="TImplementation">The implementation of the type that you want the DI to inject when the TService type is used</typeparam>
        /// <param name="services">The services collection</param>
        public static void TryAddScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.TryAddMulti<TService, TImplementation>(ServiceLifetime.Scoped);
        }

        /// <summary>
        /// This method adds the service implementation to the service collection - if it does not already exist
        /// /// The service is registed as a Transient Instance
        /// </summary>
        /// <typeparam name="TService">The interface type of the service that you want to register</typeparam>
        /// <typeparam name="TImplementation">The implementation of the type that you want the DI to inject when the TService type is used</typeparam>
        /// <param name="services">The services collection</param>
        public static void TryAddTransient<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.TryAddMulti<TService, TImplementation>(ServiceLifetime.Transient);
        }

        private static void TryAddMulti<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            if (services.Any(s => s.ServiceType == typeof(TService) && s.ImplementationType == typeof(TImplementation) && s.Lifetime == lifetime))
            {
                return;
            }

            var serviceDescriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime);
            services.Add(serviceDescriptor);
        }
    }
}
