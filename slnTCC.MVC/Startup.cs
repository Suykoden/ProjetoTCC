using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(slnTCC.MVC.Startup))]
namespace slnTCC.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
