using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KOLOKVIUMSKA.Startup))]
namespace KOLOKVIUMSKA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
