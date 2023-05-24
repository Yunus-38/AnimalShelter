using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;

namespace WebApi
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AutofacBusinessModule());
            var container = containerBuilder.Build();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

            builder.Services.AddControllers().AddControllersAsServices();

            var services = builder.Services;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Set the Autofac container as the application's service provider.
            //app.UseAutofacServiceProviderFactory(container);

            app.Run();
        }
    }


}