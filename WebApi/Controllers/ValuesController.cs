using System.Collections.Generic;
using System.Web.Http;
using Business;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // using Business Service without Dependency Injection
        private readonly BusinessService _businessService;

        public ValuesController()
        {
            _businessService = new BusinessService();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var values = _businessService.GetValues();

            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
