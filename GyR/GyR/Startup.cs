using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GyR.Startup))]
namespace GyR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
