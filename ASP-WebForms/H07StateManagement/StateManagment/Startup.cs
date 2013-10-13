using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StateManagment.Startup))]
namespace StateManagment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
