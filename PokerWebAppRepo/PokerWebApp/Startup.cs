using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokerWebApp.Startup))]
namespace PokerWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
