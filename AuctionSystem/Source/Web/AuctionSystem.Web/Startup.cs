using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionSystem.Web.Startup))]
namespace AuctionSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
