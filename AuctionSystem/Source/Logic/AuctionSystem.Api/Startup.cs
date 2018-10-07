using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AuctionSystem.Api.Startup))]

namespace AuctionSystem.Api
{
    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
