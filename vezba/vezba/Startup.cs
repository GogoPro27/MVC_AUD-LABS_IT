using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vezba.Startup))]
namespace vezba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
