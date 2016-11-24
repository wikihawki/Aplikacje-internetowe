using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ogloszenia_Studenckie.Startup))]
namespace Ogloszenia_Studenckie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
