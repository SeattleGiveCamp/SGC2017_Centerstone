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
		//private readonly IHifRepository _hifRepository;

        public HifController()
        {
            //_hifRepository = hifRepository;
            //var context = new HifContext();
            //_hifRepository = new HifRepository(context);
        }

		[HttpGet]
        public IEnumerable<HifApplication> Get()
        {
            using (var context = new HifContext())
            {
                HifRepository repo = new HifRepository(context);
                var ret = repo.GetAllApplications();
                return ret;
            }
        }

        [HttpGet("{id}")]
        public HifApplication Get(int id)
        {

            using (var context = new HifContext())
            {
                HifRepository repo = new HifRepository(context);
                var ret = repo.GetApplication(id);
                return ret;
            }
        }

        [HttpPost]
        public void Post([FromBody]Centerstone.Models.HIF hif)
        {
            bool success = false;
            using (var context = new HifContext())
            {
                HifRepository repo = new HifRepository(context);
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        HifApplication hifEntity = new HifApplication()
                        {
                            UniqueAppId = hif.UniqueApplicationId.ToString(),
                            MailingZipCode = hif.Zip,
                            //TODO: hif.HeatSourcesTypes
                            //TODO: hif.HeatSourcess
                            PhoneNumber = hif.ContactPhone,
                            Email = hif.ContactEmail,
                            HouseholdIncome = hif.MonthlyHouseholdIncome,
                            HousingStatus = hif.HouseholdStatus,
                            HousingType = hif.HouseholdType,
                            HeatSource = hif.HeatSources?.Aggregate((current, next) => current + ", " + next),
                            //TODO: HeatImages
                            //TODO: LeaseImages
                            //TODO: TipsSignatuure
                        };

                        //TODO: Adults ???
                        //TODO: Children ???

                        foreach (Person person in hif.People)
                        {
                            if (person.SocialSecurityNumber != null)
                            {
                                repo.AddPerson(new HouseholdMembers()
                                {
                                    IsPrimary = person.IsPrimary,
                                    FullName = person.FullName,
                                    DateOfBirth = person.DateOfBirth,
                                    Ssn = person.SocialSecurityNumber,
                                    PaidAdult = person.IsDesignatedAdult,
                                    //TODO: person.SocialSecurityImage
                                    //TODO: IncomeTypes = person.IncomeSources.Select(new IncomeTypes() {  } })
                                    //TODO: person.CensusData
                                });
                            }
                        }

                        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                            hifEntity.HifJsonData = reader.ReadToEnd();

                        repo.AddApplication(hifEntity);

                        transaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        [HttpPost("postimage")]
        public void PostImage(int id, string type, [FromBody]byte[] image)
        {
            throw new NotImplementedException();
        }

        [HttpGet("incomerules")]
        public IEnumerable<IncomeRules> GetIncomeRules()
        {
            using (var context = new HifContext())
            {
                HifRepository repo = new HifRepository(context);
                var ret = repo.GetIncomeRules();
                return ret;
            }
        }

        [HttpGet("test")]
        [Authorize]
        public string GetTest()
        {
            return "Hello World!";
        }
    }
}
