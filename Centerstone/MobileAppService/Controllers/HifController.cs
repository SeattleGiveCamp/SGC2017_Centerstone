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
    [Route("api/[controller]/[action]")]
    public class HifController : Controller
    {
        private HifContext context;
        private readonly IHifRepository _hifRepository;

        public HifController()
        {
            //_hifRepository = hifRepository;
            context = new HifContext();
            _hifRepository = new HifRepository(context);
        }

        [HttpGet]
        public IEnumerable<HifApplication> Get()
        {
            var ret = _hifRepository.GetAllApplications();
            return ret;

        }

        [HttpGet("{id}")]
        public HifApplication Get(int id)
        {

            var ret = _hifRepository.GetApplication(id);
            return ret;

        }

        [HttpPost]
        [ActionName("SubmitApplication")]
        public void SubmitApplication([FromBody]Centerstone.Models.HIF hif)
        {
            if (hif != null && ModelState.IsValid)
            {
                bool success = false;

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
                            HeatSources = hif.HeatSourcesTypes.Where(x => x.Value)?.Select(x=> x.Name).Aggregate((current, next) => current + ", " + next),                
                            //HeatSource = hif.HeatSources?.Aggregate((current, next) => current + ", " + next),
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
                                hifEntity.HouseholdMembers.Add(new HouseholdMembers()
                                {
                                    IsPrimary = person.IsPrimary,
                                    FullName = person.FullName,
                                    DateOfBirth = person.DateOfBirth,
                                    Ssn = person.SocialSecurityNumber,
                                    PaidAdult = person.IsDesignatedAdult,
                                    Gender = person.CensusData.Gender,
                                    RelationToPrimary = person.CensusData.Relation,
                                    Race = person.CensusData.Race,
                                    HealthInsurance = person.CensusData.HealthInsurance,
                                    MilitaryVeteran = person.CensusData.IsMilitaryVeteran,
                                    Education = person.CensusData.Education,
                                    Ethnicity = person.CensusData.Ethnicity,
                                    
                                    //TODO: person.SocialSecurityImage -  these are just a list of GUIDs for images.
                                    //TODO: IncomeTypes = person.IncomeSources.Select(new IncomeTypes() {  } })
                                    //TODO: person.CensusData
                                });
                            }
                        }

                        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                            hifEntity.HifJsonData = reader.ReadToEnd();

                        _hifRepository.AddApplication(hifEntity);

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

        [HttpPost]
        [ActionName("UploadImage")]
        public void UploadImage([FromBody] Post_R postData) //, [FromBody] int appId, [FromBody]byte[] image
        {
            int appId = int.Parse(postData.AppID);
            byte[] image = postData.Image;
            string imageId = postData.ImageID;

            if (string.IsNullOrWhiteSpace(imageId) == false
                && appId > 0
                && image != null
                && ModelState.IsValid)
            {
                var foundApp = _hifRepository.GetApplication(appId);
                if (foundApp != null && foundApp.ApplicationId == appId)
                {
                    Images objImage = new Images();
                    objImage.ApplicantGuid = imageId;

                    StoredImages storedImage = new StoredImages();
                    storedImage.ImageData = image;

                    objImage.StoredImages.Add(storedImage);
                    foundApp.Images.Add(objImage);

                    _hifRepository.UpdateImages(foundApp, objImage);
                }
                else
                {
                    throw new ApplicationException("Application could not be found.");
                }
            }
            else
            {
                throw new ApplicationException("Parameters are invalid.");
            }
        }

        [HttpGet("incomerules")]
        public IEnumerable<IncomeRules> GetIncomeRules()
        {
            var ret = _hifRepository.GetIncomeRules();
            return ret;
        }


        public bool SaveIncomeRules(IncomeRules rule)
        {
            return _hifRepository.SaveIncomeRule(rule);
        }

        [HttpPost("incomerules")]
        public void EditIncomeRule([FromBody] IncomeRules rule)
        {
            if (rule != null)
            {
                _hifRepository.UpdateIncomeRule(rule);
            }
        }

        [HttpGet("test")]
        [Authorize]
        public String GetTest()
        {
            return "Hello World!";
        }
    }

    public class Post_R
    {
        public string ImageID { get; set; }
        public string AppID { get; set; }
        public byte[] Image { get; set; }
    }
}
