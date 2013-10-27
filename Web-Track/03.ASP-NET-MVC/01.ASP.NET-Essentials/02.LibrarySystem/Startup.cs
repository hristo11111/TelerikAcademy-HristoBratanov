using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.LibrarySystem.Startup))]
namespace _02.LibrarySystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
