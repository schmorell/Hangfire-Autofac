using System.Collections.Generic;
using System.Web.Http;
using Business;
using Hangfire;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // using Business Service with Dependency Injection
        private readonly IBusinessService _businessService;

        public ValuesController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            // Simple call to the engine via Hangfire without any DI
            var engine = new Engine();

            BackgroundJob.Enqueue(() => engine.DoWork());

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
