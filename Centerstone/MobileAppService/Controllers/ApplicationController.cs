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
            throw new NotImplementedException();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Application Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Application app)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Application app)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
