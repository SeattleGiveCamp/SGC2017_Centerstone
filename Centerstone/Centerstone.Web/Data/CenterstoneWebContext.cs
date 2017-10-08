using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Centerstone.Models;

namespace Centerstone.Web.Models
{
    public class CenterstoneWebContext : DbContext
    {
        public CenterstoneWebContext (DbContextOptions<CenterstoneWebContext> options)
            : base(options)
        {
        }

        public DbSet<Centerstone.Models.IncomeGuideline> IncomeGuideline { get; set; }
    }
}
