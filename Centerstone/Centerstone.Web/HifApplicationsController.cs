using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centerstone.MobileAppService.Data;

namespace Centerstone.Web
{
    public class HifApplicationsController : Controller
    {
        private readonly HifContext _context;

        public HifApplicationsController(HifContext context)
        {
            _context = context;
        }

        // GET: HifApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.HifApplication.ToListAsync());
        }

        // GET: HifApplications/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hifApplication = await _context.HifApplication
                .SingleOrDefaultAsync(m => m.ApplicationId == id);
            if (hifApplication == null)
            {
                return NotFound();
            }

            return View(hifApplication);
        }

        // GET: HifApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HifApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,UniqueAppId,LiveStreetAddress,LiveCity,LiveState,LiveZipCode,MailingAddress,MailingCity,MailingState,MailingZipCode,Email,PhoneNumber,MessagePhone,DurationYears,DurationMonth,HousingStatus,CostMonthly,HousingType,NumberBedrooms,TotalPeople,HouseholdIncome,TargetGroup1,TargetGroup2,HeatSource,AnnualHeatCost,BackupHeatCost,UsedSurrogate,TotalEnergyCost,TotalAnnualElectricCosts,HifJsonData")] HifApplication hifApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hifApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hifApplication);
        }

        // GET: HifApplications/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hifApplication = await _context.HifApplication.SingleOrDefaultAsync(m => m.ApplicationId == id);
            if (hifApplication == null)
            {
                return NotFound();
            }
            return View(hifApplication);
        }

        // POST: HifApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ApplicationId,UniqueAppId,LiveStreetAddress,LiveCity,LiveState,LiveZipCode,MailingAddress,MailingCity,MailingState,MailingZipCode,Email,PhoneNumber,MessagePhone,DurationYears,DurationMonth,HousingStatus,CostMonthly,HousingType,NumberBedrooms,TotalPeople,HouseholdIncome,TargetGroup1,TargetGroup2,HeatSource,AnnualHeatCost,BackupHeatCost,UsedSurrogate,TotalEnergyCost,TotalAnnualElectricCosts,HifJsonData")] HifApplication hifApplication)
        {
            if (id != hifApplication.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hifApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HifApplicationExists(hifApplication.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hifApplication);
        }

        // GET: HifApplications/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hifApplication = await _context.HifApplication
                .SingleOrDefaultAsync(m => m.ApplicationId == id);
            if (hifApplication == null)
            {
                return NotFound();
            }

            return View(hifApplication);
        }

        // POST: HifApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var hifApplication = await _context.HifApplication.SingleOrDefaultAsync(m => m.ApplicationId == id);
            _context.HifApplication.Remove(hifApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HifApplicationExists(long id)
        {
            return _context.HifApplication.Any(e => e.ApplicationId == id);
        }
    }
}
