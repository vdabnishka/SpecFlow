using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LNL.MvpSpecFlow.Web.Startup))]
namespace LNL.MvpSpecFlow.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
