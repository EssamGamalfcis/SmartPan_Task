using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Services;
using Microsoft.AspNetCore.Http;

namespace SmartPan_Task_MVC.Controllers
{
    public class ManagerController : Controller
    {

        private readonly IEmployeeTaskService iemptaskservice;

        public ManagerController(IEmployeeTaskService _iemptaskservice)
        {
            iemptaskservice = _iemptaskservice;
        }


        /// <summary>
        /// The logout
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult logout()
        {
            /*session destroy*/
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserRoleId");
            return RedirectToAction("Login", "Home");
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
            try
            {
                if (int.Parse(HttpContext.Session.GetString("UserRoleId")) != 2) /*not authentication test*/
                {

                    return RedirectToAction("Login", "Home");

                }
                else
                {
                    var emptasks = iemptaskservice.GetById(int.Parse(HttpContext.Session.GetString("UserId")));
                    return View(emptasks);
                }
            }

            catch
            {
                return RedirectToAction("Login", "Home");
            }
        }
        
        // GET: Manager/Create
        public IActionResult Create()
        {
            var emptasks = iemptaskservice.GetAllEmpByManagerId(int.Parse(HttpContext.Session.GetString("UserId")));
            var tasks = iemptaskservice.GetAllTasks();
            var Taskstatus = iemptaskservice.GetAllTaskStatus();
            ViewData["EmpId"] = new SelectList(emptasks, "EmpId", "EmpFname");
            ViewData["TaskId"] = new SelectList(tasks, "TaskId", "TaskName");
            ViewData["TaskStatusId"] = new SelectList(Taskstatus, "TaskStatusId", "TaskStatus1");
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpId,TaskId,TaskStatusId")] EmployeesTasks employeesTasks)
        {
            if (ModelState.IsValid)
            {
                iemptaskservice.Add(employeesTasks);
                return RedirectToAction(nameof(Index));
            }

            var emptasks = iemptaskservice.GetAllEmpByManagerId(int.Parse(HttpContext.Session.GetString("UserId")));
            var tasks = iemptaskservice.GetAllTasks();
            var Taskstatus = iemptaskservice.GetAllTaskStatus();
            ViewData["EmpId"] = new SelectList(emptasks, "EmpId", "EmpFname", employeesTasks.EmpId);
            ViewData["TaskId"] = new SelectList(tasks, "TaskId", "TaskName", employeesTasks.TaskId);
            ViewData["TaskStatusId"] = new SelectList(Taskstatus, "TaskStatusId", "TaskStatus1", employeesTasks.TaskStatusId);
            return View(employeesTasks);
        }

    
    }
}
