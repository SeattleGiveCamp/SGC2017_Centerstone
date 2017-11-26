using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Centerstone.MobileAppService.Data
{
    public class HifRepository : IHifRepository
    {
        private HifContext context;
        private DbSet<HifApplication> hifSet;
        private DbSet<HouseholdMembers> peopleSet;
        private DbSet<IncomeRules> incomeRuleSet;

        public HifRepository(HifContext context)
        {
            this.context = context;
            hifSet = context.Set<HifApplication>();
            peopleSet = context.Set<HouseholdMembers>();
            incomeRuleSet = context.Set<IncomeRules>();
        }

        public void AddApplication(HifApplication app)
        {
            hifSet.Add(app);
            context.SaveChanges();
        }

        public HifApplication GetApplication(int id)
        {
            return hifSet.SingleOrDefault(a => a.ApplicationId == id);
        }

        public IEnumerable<HifApplication> GetAllApplications()
        {
            return hifSet.AsEnumerable();
        }

        public void RemoveApplication(int id)
        {
            HifApplication app = GetApplication(id);
            hifSet.Remove(app);
            context.SaveChanges();
        }

        public void UpdateApplication(HifApplication app)
        {
            context.Entry(app).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdateImages(HifApplication app, Images newImage)
        {
            if (app.Images.Contains(newImage) == false)
            {
                app.Images.Add(newImage);
            }
            context.Images.Add(newImage);
            UpdateApplication(app);
        }

        public void AddPerson(HouseholdMembers person)
        {
            peopleSet.Add(person);
            context.SaveChanges();
        }

        public HouseholdMembers GetPerson(int id)
        {
            return peopleSet.SingleOrDefault(p => p.PersonId == id);
        }

        public IEnumerable<IncomeRules> GetIncomeRules()
        {
            return incomeRuleSet.AsEnumerable();
        }

        public void UpdateIncomeRule(IncomeRules rule)
        {
            context.Entry(rule).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
