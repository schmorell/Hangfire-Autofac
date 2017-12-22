using Hangfire;

namespace HangfireService
{
    public class JobService
    {
        private BackgroundJobServer _backgroundJobServer;

        public void Start()
        {
            // Start code here...
            _backgroundJobServer = new BackgroundJobServer();
        }

        public void Stop()
        {
            // Stop code here...
            _backgroundJobServer.Dispose();
        }
    }
}
