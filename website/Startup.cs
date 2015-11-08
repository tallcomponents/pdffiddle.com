using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PdfFiddle.Startup))]
namespace PdfFiddle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
