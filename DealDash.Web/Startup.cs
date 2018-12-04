using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealDash.Web.Startup))]
namespace DealDash.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
