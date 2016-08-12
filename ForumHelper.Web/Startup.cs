using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumHelper.Web.Startup))]
namespace ForumHelper.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
