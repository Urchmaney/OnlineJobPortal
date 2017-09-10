using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJobPortal3.Startup))]
namespace OnlineJobPortal3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
