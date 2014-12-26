using Hangfire.SqlServer;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Hangfire.Highlighter.Startup))]

namespace Hangfire.Highlighter
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //careates required db's for hangfire.
            app.UseHangfire(
                config => config.UseSqlServerStorage("HighlighterDb"));
        }
      
    }
}