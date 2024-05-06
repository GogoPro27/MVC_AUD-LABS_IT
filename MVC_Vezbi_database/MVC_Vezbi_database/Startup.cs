using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Vezbi_database.Startup))]
namespace MVC_Vezbi_database
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
