using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<object> Get([FromQuery]string type, [FromQuery]string value)
        {
            //string type = "type";
            //string value = "2";
            string url = $"https://opgapim.azure-api.cn/api/operation/{type}/{value}";


            HttpClient httpClient = new HttpClient();

            string ResourceKey = "89a847882152472d995405adea2caf1f";

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ResourceKey);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            return await response.Content.ReadAsStringAsync();

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
