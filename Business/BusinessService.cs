using System.Collections.Generic;

namespace Business
{
    public interface IBusinessService
    {
        IEnumerable<string> GetValues();
    }
    public class BusinessService : IBusinessService
    {
        public IEnumerable<string> GetValues()
        {
            return new[] { "value1", "value3" };
        }
    }
}
