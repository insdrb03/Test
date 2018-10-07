using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp_TEST.Startup))]
namespace WebApp_TEST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
