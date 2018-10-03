using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airport.WebUI.Startup))]
namespace Airport.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
