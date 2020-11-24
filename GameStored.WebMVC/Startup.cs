using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameStored.WebMVC.Startup))]
namespace GameStored.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
