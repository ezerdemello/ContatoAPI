using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContatoAPI.Service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/Contato
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Contato/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Contato
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Contato/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Contato/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
