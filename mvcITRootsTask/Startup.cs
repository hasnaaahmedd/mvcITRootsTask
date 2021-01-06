using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcITRootsTask.Startup))]
namespace mvcITRootsTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
