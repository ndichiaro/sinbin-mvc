using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sinbin.Web.Startup))]
namespace Sinbin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
