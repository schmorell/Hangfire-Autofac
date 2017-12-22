using System;

namespace Business
{
    public interface IEngine
    {
        void DoWork();
    }

    public class Engine : IEngine
    {
        private readonly Guid _workerId;

        public Engine()
        {
            _workerId = Guid.NewGuid();
        }

        public void DoWork()
        {
            Console.WriteLine("I am working. My id is {0}.", _workerId);

            Console.WriteLine("  Step 1: ");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("  Step 2: ");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
