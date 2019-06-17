using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Services;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace SmartPan_Task_MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeService iEmployeeService;
        private readonly IFileProvider fileProvider;
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="_iTaskService">The _iTaskService<see cref="ITaskService"/></param>
        public AdminController(IEmployeeService _iEmployeeService ,  IFileProvider fileprovider, IHostingEnvironment env)
        {
            iEmployeeService = _iEmployeeService;
            fileProvider = fileprovider;
            hostingEnvironment = env;

        }


       

        public IActionResult logout()
        {
            /*session destroy*/
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserRoleId");
            return RedirectToAction("Login", "Home");

        }
        public IActionResult Departements()
        {
            return RedirectToAction("Index", "Departements");
        }


        [HttpPost]
        public async Task<IActionResult> Search(string SearchWord)
        {
           
            var employees = iEmployeeService.FindBY(SearchWord);
            if (employees == null)
            {
                employees = new Employees();
                ModelState.AddModelError("CustomError", "Not Found");
                return View(employees);
            }

            return View(employees);
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            try
            {
                if (int.Parse(HttpContext.Session.GetString("UserRoleId")) != 1)/*not authentication test*/
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {

                    return View(iEmployeeService.GetAll().ToList().Where(a => a.DeleteFlag != 1));

                }
            }
            catch
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employees =  iEmployeeService.GetById(id.GetValueOrDefault());
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }



        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepId"] = new SelectList(iEmployeeService.GetAllDepartements(), "DepId", "DepName");
            ViewData["EmpId"] = new SelectList(iEmployeeService.GetAllUsers(), "UserId", "UserLoginName");
            ViewData["ManagerId"] = new SelectList(iEmployeeService.GetAll(), "EmpId", "EmpFname");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpFname,EmpLname,EmpSalary,EmpImage,ManagerId,DepId")] Employees employees, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                FileInfo fi = new FileInfo(file.FileName);
                var newFilename = employees.EmpImage + "_" + String.Format("{0:d}",
                              (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                var webPath = hostingEnvironment.WebRootPath;
                var path = Path.Combine("", webPath + @"\images\" + newFilename);
                var pathToSave = @"/images/" + newFilename;
                employees.EmpImage = pathToSave;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }



                iEmployeeService.Add(employees);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepId"] = new SelectList(iEmployeeService.GetAllDepartements(), "DepId", "DepName", employees.DepId);
            ViewData["EmpId"] = new SelectList(iEmployeeService.GetAllUsers(), "UserId", "UserLoginName", employees.EmpId);
            ViewData["ManagerId"] = new SelectList(iEmployeeService.GetAll(), "EmpId", "EmpFname", employees.ManagerId);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = iEmployeeService.GetById(id.GetValueOrDefault());
            if (employees == null)
            {
                return NotFound();
            }
            ViewData["DepId"] = new SelectList(iEmployeeService.GetAllDepartements(), "DepId", "DepName", employees.DepId);
            ViewData["EmpId"] = new SelectList(iEmployeeService.GetAllUsers(), "UserId", "UserLoginName", employees.EmpId);
            ViewData["ManagerId"] = new SelectList(iEmployeeService.GetAll(), "EmpId", "EmpFname", employees.ManagerId);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpFname,EmpLname,EmpSalary,EmpImage,ManagerId,DepId")] Employees employees, IFormFile file)
        {
            if (id != employees.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    var newFilename = employees.EmpImage + "_" + String.Format("{0:d}",
                                  (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\images\" + newFilename);
                    var pathToSave = @"/images/" + newFilename;
                    employees.EmpImage = pathToSave;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    iEmployeeService.Update(employees);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.EmpId))
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
            ViewData["DepId"] = new SelectList(iEmployeeService.GetAllDepartements(), "DepId", "DepName", employees.DepId);
            ViewData["EmpId"] = new SelectList(iEmployeeService.GetAllUsers(), "UserId", "UserLoginName", employees.EmpId);
            ViewData["ManagerId"] = new SelectList(iEmployeeService.GetAll(), "EmpId", "EmpFname", employees.ManagerId);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = iEmployeeService.GetById(id.GetValueOrDefault());
             
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = iEmployeeService.GetById(id);
            employees.DeleteFlag = 1;
            iEmployeeService.Update(employees);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return iEmployeeService.GetAll().Any(e => e.EmpId == id);
        }
    }
}
