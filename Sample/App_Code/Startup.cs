using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practise.Startup))]
namespace Practise
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
