using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Business;
using Hangfire;
using Owin;

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Autofac configuration
            var builder = new ContainerBuilder();

            builder.RegisterType<BusinessService>().As<IBusinessService>().InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Hangfire configuration
            GlobalConfiguration.Configuration.UseSqlServerStorage("DbContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}