using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB_3.Startup))]
namespace LAB_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
