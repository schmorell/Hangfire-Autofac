using System;
using System.Collections.Generic;

namespace Business
{
    public interface IBusinessService
    {
        IEnumerable<string> GetValues();
    }
    public class BusinessService : IBusinessService
    {
        private readonly Guid _serviceId;

        public BusinessService()
        {
            _serviceId = Guid.NewGuid();
        }
        public IEnumerable<string> GetValues()
        {
            return new[] { "value1", "value3" };
        }
    }
}
