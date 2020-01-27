using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Solution_servico.Startup))]
namespace Solution_servico
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
