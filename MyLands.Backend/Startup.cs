using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyLands.Backend.Startup))]
namespace MyLands.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
