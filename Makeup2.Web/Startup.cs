using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Makeup2.Web.Startup))]
namespace Makeup2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
