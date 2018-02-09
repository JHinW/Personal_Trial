using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDI.source;

namespace WebDI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private Test _test;

        private Test _test2;

        private IEnumerable<Test3> _test3List;
             
        public ValuesController(Test test, 
            Test test2,
            IEnumerable<Test3> test3List
            )
        {
            _test = test;
            _test2 = test2;
            _test3List = test3List;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return new Test[] { _test, _test2 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Test3> Get(int id)
        {
            return _test3List;
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
