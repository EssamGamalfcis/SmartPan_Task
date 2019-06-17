using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using SmartPan_Task.Models;
using Microsoft.AspNetCore.Http;

namespace SmartPan_Task.Controllers
{
    public class HomeController : Controller
    {
       //private readonly UsersService userServices=new UsersService();


       private readonly IUsersService iusersService;



        public HomeController(IUsersService _iuserService)
        {
            this.iusersService = _iuserService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username , string password)
        {

            Users user= iusersService.Login(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserRoleId", user.UserRoleId.ToString());

                //Session["UserId"] = user.UserId;
            }
            if (user == null)
            {
                ModelState.AddModelError("CustomError", "Login faild");
                return View();
            }
            else if (user.UserRoleId == 1) //Admin
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (user.UserRoleId == 2) //Manager
            {
                return RedirectToAction("Index", "Manager");
            }
            else if (user.UserRoleId == 3) //Employee
            {
                return RedirectToAction("Index", "Employee");
            }

            
                return View();

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
