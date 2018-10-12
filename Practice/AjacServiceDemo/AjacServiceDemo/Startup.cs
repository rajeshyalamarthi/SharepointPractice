using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjacServiceDemo.Startup))]
namespace AjacServiceDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
