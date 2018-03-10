using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centerstone.Web.Models;
using Centerstone.MobileAppService.Data;
using Centerstone.MobileAppService.Controllers;

namespace Centerstone.Web.Controllers
{
    public class IncomeGuidelinesController : Controller
    {
        private HifController hifCont;
        public IncomeGuidelinesController()
        {
            hifCont = new HifController();
        }

        // GET: IncomeGuidelines
        public async Task<IActionResult> Index()
        {
            var results = hifCont.GetIncomeRules();

            return View(results);
        }
        [HttpGet]
        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeGuidelines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("RowId,HouseholdSize,MaxIncome")] IncomeRules incomeGuideline)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            return View(incomeGuideline);
        }

        // GET: IncomeGuidelines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Bad Request.");
            }

            //Sample: await _context.IncomeGuideline.SingleOrDefaultAsync(m => m.myKey == id);

            var incomeGuideline = hifCont.GetIncomeRules().FirstOrDefault(r => r.RowId == id);
            
            if (incomeGuideline == null)
            {
                ModelState.AddModelError("", "Record not found");
            }
            return View(incomeGuideline);
        }

        // POST: IncomeGuidelines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseholdSize,MaxIncome")] IncomeRules incomeGuideline)
        {
            //if (id != incomeGuideline.RowId)
            if (id <= 0)
            {
                ModelState.AddModelError("", "Bad Request.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    incomeGuideline.RowId = id;
                    hifCont.EditIncomeRule(incomeGuideline);
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        ModelState.AddModelError("", "Database error!");
                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error connecting to the data store.");
                }
            }
            return View(incomeGuideline);
        }
        
        // POST: IncomeGuidelines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //TODO: call DELETE guideline.
            return RedirectToAction(nameof(Index));
        }

        //private bool IncomeGuidelineExists(int id)
        //{
        //    return false; //TODO: call GET api
        //    //return _context.IncomeGuideline.Any(e => e.myKey == id);
        //}
    }
}
