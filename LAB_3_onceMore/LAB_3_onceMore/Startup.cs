using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB_3_onceMore.Startup))]
namespace LAB_3_onceMore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
