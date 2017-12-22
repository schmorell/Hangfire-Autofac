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

            // This is the registration needed if the need to be available in different scopes:
            // https://github.com/HangfireIO/Hangfire.Autofac
            builder.RegisterType<BusinessService>().As<IBusinessService>().InstancePerRequest(AutofacJobActivator.LifetimeScopeTag);
            builder.RegisterType<Engine>().As<IEngine>().InstancePerRequest(AutofacJobActivator.LifetimeScopeTag);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.UseAutofacActivator(container);

            // Hangfire configuration
            GlobalConfiguration.Configuration.UseSqlServerStorage("DbContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}