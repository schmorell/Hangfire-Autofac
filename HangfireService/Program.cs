using Autofac;
using Business;
using Hangfire;
using Topshelf;

namespace HangfireService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hangfire configuration
            GlobalConfiguration.Configuration.UseSqlServerStorage("DbContext");

            // Autofac configuration
            var builder = new ContainerBuilder();

            builder.RegisterType<BusinessService>().As<IBusinessService>().InstancePerBackgroundJob();
            builder.RegisterType<Engine>().As<IEngine>().InstancePerBackgroundJob();

            var container = builder.Build();

            GlobalConfiguration.Configuration.UseAutofacActivator(container);

            // Topshelf configuration
            HostFactory.Run(x =>
            {
                x.Service<JobService>(s =>
                {
                    s.ConstructUsing(name => new JobService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStopped(rs => rs.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Jobs Service");
                x.SetDisplayName("JobsService");
                x.SetServiceName("JobsService");
            });
        }
    }
}
