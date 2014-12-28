using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyWebApplication.Startup))]

namespace MyWebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfire(config =>
            {
                //The SqlServerStorage class will install all database tables automatically 
                //on application start-up (but you are able to do it manually).

                config.UseSqlServerStorage("emailDb");
                config.UseServer();
            });
        }
    }
}
