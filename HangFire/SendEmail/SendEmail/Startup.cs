using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(SendEmail.Startup))]
namespace SendEmail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage("<name or connection string>");
                config.UseServer();
            });
        }
    }
}
