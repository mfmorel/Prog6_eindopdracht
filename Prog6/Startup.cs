using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prog6.Startup))]
namespace Prog6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
