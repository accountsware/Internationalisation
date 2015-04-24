using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcInternationalization.Startup))]
namespace MvcInternationalization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
