using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VIS.Startup))]
namespace VIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
