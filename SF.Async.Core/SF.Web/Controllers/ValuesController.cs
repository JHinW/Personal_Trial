using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SF.Web.Main;

namespace SF.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var applicationName = "fabric:/SF.Stateful";
            var serviceName = $"{applicationName}/SF.Stateful.Test";

            var service = this.GetStateFulService(new Uri(serviceName));
            try
            {
                /*
                var result = await service.DataFromBasicTypeAsync("ssss");

                return new string[] { "value1", result.ID };
                */

            }
            catch (Exception e)
            {
                throw e;
            }


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
