using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Underwatch.Startup))]
namespace Underwatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
