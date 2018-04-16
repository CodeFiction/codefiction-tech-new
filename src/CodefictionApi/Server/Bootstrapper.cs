using Autofac;
using Microsoft.AspNetCore.Hosting;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;

namespace Codefiction.CodefictionTech.CodefictionApi.Server
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private readonly ILifetimeScope _container;

        public Bootstrapper(ILifetimeScope container, IHostingEnvironment env)
        {
            _container = container;

            RootPathProvider = new AppRootPathProvider(env);

        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return _container;
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.AddDirectory("dist");

            //conventions.StaticContentsConventions.AddDirectory("css");
            //conventions.StaticContentsConventions.AddDirectory("js");
            //conventions.StaticContentsConventions.AddDirectory("fonts");
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
        }

        protected override IRootPathProvider RootPathProvider { get; }
    }
}