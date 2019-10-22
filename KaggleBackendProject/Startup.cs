using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaggleBackendProject.Startup))]
namespace KaggleBackendProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
