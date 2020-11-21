using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_CashBank.Startup))]
namespace e_CashBank
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
