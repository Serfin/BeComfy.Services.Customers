using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.CqrsFlow;
using BeComfy.Services.Customers.Application.Commands;
using Microsoft.Extensions.Hosting;
using BeComfy.Services.Customers.Infrastructure.EFCore;
using BeComfy.Common.EFCore;
using BeComfy.Common.Jaeger;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BeComfy.Common;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Services.Customers.Application.Commands.CommandHandlers;
using BeComfy.Services.Customers.Core.Repositories;
using BeComfy.Services.Customers.Infrastructure.Repositories;
using BeComfy.Common.CqrsFlow.Dispatcher;

namespace BeComfy.Services.Customers.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICommandHandler<CreateCustomer>, CreateCustomerHandler>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddEFCoreContext<CustomersContext>();

            var builder = new ContainerBuilder();            
            builder.Populate(services);
            builder.AddRabbitMq();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseRabbitMq()
                .SubscribeCommand<CreateCustomer>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
