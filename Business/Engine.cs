using System;
using System.Linq;

namespace Business
{
    public interface IEngine
    {
        void DoWork();
    }

    public class Engine : IEngine
    {
        private readonly IBusinessService _businessService;
        private readonly Guid _workerId;

        public Engine(IBusinessService businessService)
        {
            _businessService = businessService;
            _workerId = Guid.NewGuid();
        }

        public void DoWork()
        {
            Console.WriteLine("I am working. My id is {0}.", _workerId);

            var values = _businessService.GetValues();
            var enumerable = values as string[] ?? values.ToArray();

            Console.WriteLine("  Step 1: " + enumerable.First());
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("  Step 2: " + enumerable.Last());
            System.Threading.Thread.Sleep(1000);
        }
    }
}
