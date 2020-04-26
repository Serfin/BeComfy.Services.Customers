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
using BeComfy.Services.Customers.Application.Queries;
using BeComfy.Services.Customers.Application.Dto;
using BeComfy.Services.Customers.Application.Queries.QueryHandlers;
using BeComfy.Services.Customers.Application.Events;
using BeComfy.Services.Customers.Application.Events.EventHandlers;
using BeComfy.Services.Customers.Core.Entities;
using BeComfy.Common.Mongo;
using BeComfy.Logging.Elk;

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
            services.AddTransient<ICommandHandler<CreateCustomer>, CreateCustomerHandler>();
            services.AddTransient<ICommandHandler<IncreaseCustomerBalance>, IncreaseCustomerBalanceHandler>();
            services.AddTransient<ICustomersRepository, MongoCustomersRepository>();
            services.AddTransient<IEventHandler<TicketBought>, TicketBoughtHandler>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<IQueryHandler<GetCustomer, CustomerDto>, GetCustomerHandler>();
            
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddMongo();
            services.AddMongoRepository<Customer>("Customers");
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
                .SubscribeCommand<CreateCustomer>(
                    onError: (cmd, ex) => new CreateCustomerRejected(cmd.Id, ex.Code, ex.Message))
                .SubscribeCommand<IncreaseCustomerBalance>(
                    onError: (cmd, ex) => new IncreaseCustomerBalanceRejected(cmd.CustomerId, ex.Code, ex.Message))
                .SubscribeEvent<TicketBought>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
