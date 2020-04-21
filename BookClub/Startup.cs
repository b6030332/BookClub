using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookClub.Startup))]
namespace BookClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
