using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginSnippet.Startup))]
namespace LoginSnippet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
