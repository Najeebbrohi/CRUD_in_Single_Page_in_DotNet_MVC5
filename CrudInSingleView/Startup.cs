using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudInSingleView.Startup))]
namespace CrudInSingleView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
