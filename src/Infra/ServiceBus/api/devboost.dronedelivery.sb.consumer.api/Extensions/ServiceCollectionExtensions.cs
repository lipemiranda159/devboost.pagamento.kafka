using devboost.dronedelivery.sb.application;
using devboost.dronedelivery.sb.domain.Interfaces;
using devboost.dronedelivery.sb.service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.consumer.api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<IConsumer, ConsumerService>();
            services.AddSingleton<IProcessorQueue, ProcessorService>();
            services.AddSingleton<ILoginProvider, LoginProvider>();
            services.AddSingleton<IServiceFactory, ServiceFactory>();

        }
    }
}
