using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVSiteGrupp15.Startup))]
namespace CVSiteGrupp15
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
