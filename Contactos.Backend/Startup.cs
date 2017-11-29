using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contactos.Backend.Startup))]
namespace Contactos.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
