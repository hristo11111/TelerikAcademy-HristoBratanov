using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamWebFormsASP.Startup))]
namespace ExamWebFormsASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
