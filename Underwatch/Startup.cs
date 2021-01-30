using Autofac;
using Autofac.Integration.Mvc;
using Contracts;
using Microsoft.Owin;
using Owin;
using Services;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Underwatch.Startup))]
namespace Underwatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<NewsService>().As<INewsService>();
            builder.RegisterType<FavoritesService>().As<IFavoritesService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ConfigureAuth(app);
        }
    }
}
