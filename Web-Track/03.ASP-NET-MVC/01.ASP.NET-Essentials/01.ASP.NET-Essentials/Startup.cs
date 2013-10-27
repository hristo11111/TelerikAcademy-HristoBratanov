using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.ASP.NET_Essentials.Startup))]
namespace _01.ASP.NET_Essentials
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
