using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;

namespace Codefiction.CodefictionTech.CodefictionApi.Server
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        public static IContainer Container { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();

            services.AddNodeServices();

            builder.Populate(services);

            builder.RegisterType<Service>().As<IService>();

            Container = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                await next.Invoke(); //let the rest of the pipeline run
            });

            app.UseOwin(action => action.UseNancy(options => options.Bootstrapper = new Bootstrapper(Container, env)));
        }
    }

    public interface IService
    {

    }

    public class Service : IService
    {

    }
}


