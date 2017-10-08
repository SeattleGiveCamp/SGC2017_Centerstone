using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centerstone.Models;
using Centerstone.Web.Models;

namespace Centerstone.Web.Controllers
{
    public class IncomeGuidelinesController : Controller
    {
        // GET: IncomeGuidelines
        public async Task<IActionResult> Index()
        {
            //TODO: get list of guidelines.
            List<IncomeGuideline> list = new List<IncomeGuideline>()
            {
                new IncomeGuideline(){HouseholdSize=1, MaxIncome=1256 },
                new IncomeGuideline(){HouseholdSize=2, MaxIncome=1692 },
                new IncomeGuideline(){HouseholdSize=3, MaxIncome=2127 },
                new IncomeGuideline(){HouseholdSize=4, MaxIncome=2563 },
                new IncomeGuideline(){HouseholdSize=5, MaxIncome=2998 },

            };


            return View(list);
        }

        // GET: IncomeGuidelines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            object incomeGuideline = null; //TODO: get the guideline.
            if (incomeGuideline == null)
            {
                return NotFound();
            }

            return View(incomeGuideline);
        }

        // GET: IncomeGuidelines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeGuidelines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("myKey,HouseholdSize,MaxIncome")] IncomeGuideline incomeGuideline)
        {
            if (ModelState.IsValid)
            {
                //TODO: Call Save New IncomeGuidelines.
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
            object incomeGuideline = null; //TODO: call GetIncomeGuideline, switch back to var.
            
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
        public async Task<IActionResult> Edit(int id, [Bind("myKey,HouseholdSize,MaxIncome")] IncomeGuideline incomeGuideline)
        {
            if (id != incomeGuideline.myKey)
            {
                ModelState.AddModelError("", "Bad Request.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Call Edit Guidelines
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeGuidelineExists(incomeGuideline.myKey))
                    {
                        ModelState.AddModelError("", "Record not found");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Database error!");
                    }
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

        private bool IncomeGuidelineExists(int id)
        {
            return false; //TODO: call GET api
            //return _context.IncomeGuideline.Any(e => e.myKey == id);
        }
    }
}
