using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrewApp.Startup))]
namespace BrewApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
