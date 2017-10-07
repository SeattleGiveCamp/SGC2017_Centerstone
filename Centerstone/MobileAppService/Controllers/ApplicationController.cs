using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centerstone.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Centerstone.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Application> Get()
        {
            return new Application();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return new Application();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Application app)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Application app)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
