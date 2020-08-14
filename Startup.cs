using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cppPLUS_2407.Startup))]
namespace cppPLUS_2407
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
