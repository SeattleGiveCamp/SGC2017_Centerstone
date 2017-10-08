﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centerstone.MobileAppService.Data
{
	public interface IApplicationRepository
	{
		void Add(HifApplication app);
		void Update(HifApplication app);
        void Remove(int id);
        HifApplication Get(int id);
		IEnumerable<HifApplication> GetAll();
	}
}
