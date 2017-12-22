using Hangfire;
using Owin;

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DbContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}