using devboost.dronedelivery.core.domain.Constants;
using devboost.dronedelivery.sb.application;
using devboost.dronedelivery.sb.consumer.api.Extensions;
using devboost.dronedelivery.sb.consumer.api.Filter;
using devboost.dronedelivery.sb.domain.Interfaces;
using devboost.dronedelivery.sb.service;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace devboost.dronedelivery.sb.consumer.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingletons(Configuration);
            services.AddHangfire(config => config.UseMemoryStorage());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseHangfireDashboard("/server", options: new DashboardOptions()
            {
                Authorization = new[] { new AuthorizationFilter() }
            });
            app.UseHangfireServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var processorQueue = app.ApplicationServices.GetService<IProcessorQueue>();
            var recurringJobManager = app.ApplicationServices.GetService<IRecurringJobManager>();
            recurringJobManager.AddOrUpdate(Guid.NewGuid().ToString(), () => processorQueue.ProcessorQueueAsync(CoreConstants.PedidoTopic), "*/5 * * * * *");
            recurringJobManager.AddOrUpdate(Guid.NewGuid().ToString(), () => processorQueue.ProcessorQueueAsync(CoreConstants.PagamentoTopic), "*/5 * * * * *");

        }
    }
}
