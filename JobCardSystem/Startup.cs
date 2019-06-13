using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobCardSystem.Startup))]
namespace JobCardSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
