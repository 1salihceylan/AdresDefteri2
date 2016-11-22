using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADRESDEFTERI.Startup))]
namespace ADRESDEFTERI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
