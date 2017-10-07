using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centerstone.MobileAppService.Data;
using Centerstone.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Centerstone.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
		private readonly IApplicationRepository _applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

		[HttpGet]
        public IEnumerable<Application> Get()
        {
            return _applicationRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Application Get(int id)
        {
            return _applicationRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Application app)
        {
            _applicationRepository.Add(app);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Application app)
        {
            _applicationRepository.Update(app);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _applicationRepository.Remove(id);
        }
    }
}
