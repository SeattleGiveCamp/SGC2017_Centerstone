using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centerstone.MobileAppService.Models;

namespace Centerstone.MobileAppService.Data
{
	public interface IApplicationRepository
	{
		void Add(Application app);
		void Update(Application app);
		Application Remove(int id);
		Application Get(int id);
		IEnumerable<Application> GetAll();
	}
}
