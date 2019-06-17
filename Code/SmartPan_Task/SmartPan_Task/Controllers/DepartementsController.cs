using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Services;

namespace SmartPan_Task_MVC.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly IDepartementService iDepatementService;

        public DepartementsController(IDepartementService _iDepatementService)
        {
            iDepatementService = _iDepatementService;
        }


        public IActionResult Employees()
        {
            return RedirectToAction("Index", "Admin");
        }


        public async Task<IActionResult> Search(string SearchWord)
        {

            var departement = iDepatementService.FindBy(SearchWord);
            
            if (departement == null)
            {
                departement = new Departements();
                ModelState.AddModelError("CustomError", "Not Found");
                return View(departement);
            }
            ViewBag.Count= departement.Employees.Count();
            return View(departement);
        }

        public IActionResult logout()
        {
            /*session destroy*/
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Home");

        }
        // GET: Departements
        public async Task<IActionResult> Index()
        {
            try 
            {
                TempData["Error"].ToString();
                ViewBag.ErrorMessage = "This Departement Realated to Employees 'Cannot be deleted'";
                return View(iDepatementService.GetAll().Where(a => a.DeleteFlag != 1));
            }
            
            catch {
                return View(iDepatementService.GetAll().Where(a => a.DeleteFlag != 1));
            }
        }

        // GET: Departements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departements = iDepatementService.GetById(id.GetValueOrDefault());

            if (departements == null)
            {
                return NotFound();
            }

            return View(departements);
        }

        // GET: Departements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepId,DepName")] Departements departements)
        {
            if (ModelState.IsValid)
            {
                iDepatementService.Insert(departements);
                 return RedirectToAction(nameof(Index));
            }
            return View(departements);
        }

        // GET: Departements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departements = iDepatementService.GetById(id.GetValueOrDefault());
            if (departements == null)
            {
                return NotFound();
            }
            return View(departements);
        }

        // POST: Departements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepId,DepName")] Departements departements)
        {
            if (id != departements.DepId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(departements);
                    //await _context.SaveChangesAsync();
                    iDepatementService.Update(departements);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartementsExists(departements.DepId))
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
            return View(departements);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employees = iDepatementService.GetAllEmp(id.GetValueOrDefault());
            if (employees.Count > 0)
            {
                TempData["Error"] = "NotConfirm";
                return RedirectToAction("Index");
            }
            
            
            var departements = iDepatementService.GetById(id.GetValueOrDefault());
            if (departements == null)
            {
                return NotFound();
            }

            return View(departements);
        }

        // POST: Departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departement = iDepatementService.GetById(id);
            departement.DeleteFlag = 1;
            iDepatementService.Update(departement);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartementsExists(int id)
        {
            return iDepatementService.GetAll().Any(e => e.DepId == id);
        }
    }
}
