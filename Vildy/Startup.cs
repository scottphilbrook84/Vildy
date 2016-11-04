using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vildy.Startup))]
namespace Vildy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
