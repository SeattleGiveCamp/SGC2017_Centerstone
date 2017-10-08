using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centerstone.MobileAppService.Data;
using Microsoft.AspNetCore.Mvc;

namespace Centerstone.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class HifController : Controller
    {
		private readonly IHifRepository _hifRepository;

        public HifController(IHifRepository hifRepository)
        {
            _hifRepository = hifRepository;
        }

		[HttpGet]
        public IEnumerable<HifApplication> Get()
        {
            return _hifRepository.GetAll();
        }

        [HttpGet("{id}")]
        public HifApplication Get(int id)
        {
            return _hifRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]HifApplication app)
        {
            _hifRepository.Add(app);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]HifApplication app)
        {
            _hifRepository.Update(app);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hifRepository.Remove(id);
        }
    }
}
