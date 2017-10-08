using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Centerstone.MobileAppService.Data;
using Centerstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
            return _hifRepository.GetAllApplications();
        }

        [HttpGet("{id}")]
        public HifApplication Get(int id)
        {
            return _hifRepository.GetApplication(id);
        }

        [HttpPost]
        public void Post([FromBody]HIF hif)
        {
            HifApplication entity = new HifApplication()
            {
                UniqueAppId = hif.UniqueApplicationId.ToString(),
                PhoneNumber = hif.ContactPhone,
                Email = hif.ContactEmail,
                HouseholdIncome = hif.MonthlyHouseholdIncome,
                HousingStatus = hif.HouseholdStatus,
                HousingType = hif.HouseholdType,
                HeatSource = hif.HeatSources.Aggregate((current, next) => current + ", " + next)
            };

            foreach (Person person in hif.People)
            {
                _hifRepository.AddPerson(new HouseholdMembers()
                {
                    IsPrimary = person.IsPrimary,
                    FullName = person.FullName,
                    DateOfBirth = person.DateOfBirth,
                    Ssn = person.SocialSecurityNumber
                });
            }

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                entity.HifJsonData = reader.ReadToEnd();

			_hifRepository.AddApplication(entity);
        }

        [HttpPost("postimage")]
        public void PostImage(int id, string type, [FromBody]byte[] image)
        {
            throw new NotImplementedException();
        }

        [HttpGet("incomerules")]
        public IEnumerable<IncomeRules> GetIncomeRules()
        {
            return _hifRepository.GetIncomeRules();
        }

        [HttpGet("test")]
        [Authorize]
        public string GetTest()
        {
            return "Hello World!";
        }
    }
}
