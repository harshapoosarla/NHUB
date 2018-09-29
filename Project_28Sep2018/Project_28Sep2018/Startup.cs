using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_28Sep2018.Startup))]
namespace Project_28Sep2018
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
