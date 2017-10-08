using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centerstone.MobileAppService.Data
{
    public interface IHifRepository
	{
		void AddApplication(HifApplication app);
		void UpdateApplication(HifApplication app);
        void RemoveApplication(int id);
        HifApplication GetApplication(int id);
		IEnumerable<HifApplication> GetAllApplications();
        void AddPerson(HouseholdMembers person);
        HouseholdMembers GetPerson(int id);
        IEnumerable<IncomeRules> GetIncomeRules();
	}
}
