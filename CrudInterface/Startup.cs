using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudInterface.Startup))]
namespace CrudInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
