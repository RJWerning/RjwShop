using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RjwShop.WebUI.Startup))]
namespace RjwShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
