using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirportSystem.Startup))]
namespace AirportSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
