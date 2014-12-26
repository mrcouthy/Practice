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
            app.UseHangfire(
                config => config.UseSqlServerStorage("TryHf"));
        }
      
    }
}