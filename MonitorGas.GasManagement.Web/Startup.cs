using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonitorGas.GasManagement.Web.Startup))]
namespace MonitorGas.GasManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureAuth0(app);
            //ConfigureAuth0ApiToken(app);
        }
    }
}
