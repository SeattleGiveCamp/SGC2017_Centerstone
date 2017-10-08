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
        private DbSet<IncomeRules> incomeRuleSet;

        public HifRepository(HifContext context)
        {
            this.context = context;
            hifSet = context.Set<HifApplication>();
            incomeRuleSet = context.Set<IncomeRules>();
        }

        public void Add(HifApplication app)
        {
            hifSet.Add(app);
            context.SaveChanges();
        }

        public HifApplication Get(int id)
        {
            return hifSet.SingleOrDefault(a => a.ApplicationId == id);
        }

        public IEnumerable<HifApplication> GetAll()
        {
            return hifSet.AsEnumerable();
        }

        public void Remove(int id)
        {
            HifApplication app = Get(id);
            hifSet.Remove(app);
            context.SaveChanges();
        }

        public void Update(HifApplication app)
        {
            context.Entry(app).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<IncomeRules> GetIncomeRules()
        {
            return incomeRuleSet.AsEnumerable();
        }
    }
}
