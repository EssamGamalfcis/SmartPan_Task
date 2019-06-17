namespace SmartPan_Task_MVC.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="EmployeeController" />
    /// </summary>
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Defines the iTaskService
        /// </summary>
        private readonly ITaskService iTaskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="_iTaskService">The _iTaskService<see cref="ITaskService"/></param>
        public EmployeeController(ITaskService _iTaskService)
        {
            //_context = context;
            this.iTaskService = _iTaskService;
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

        // GET: Employees
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        public async Task<IActionResult> Index()
        {

            try
            {
                if (int.Parse(HttpContext.Session.GetString("UserRoleId")) != 3)/*not authentication test*/
                {
                    
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return View(iTaskService.GetAll(int.Parse(HttpContext.Session.GetString("UserId"))));

                }
            }
            catch
            {
                return RedirectToAction("Login", "Home");

            }
        }
          
        

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employees_tasks = iTaskService.GetEmplTaskById(id.GetValueOrDefault());
            var tasks_status = iTaskService.GetTaskStatus().Select(a => a.TaskStatus1).ToList();
            var tasks_names = iTaskService.GetTasks().Select(a => a.TaskName).ToList();
            if (employees_tasks == null)
            {
                return NotFound();
            }
            ViewBag.Tasks_Status = tasks_status;
            ViewBag.Tasks_Names = tasks_names;
            return View(employees_tasks);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {


            string Task_State = Request.Form["Task_Status"].ToString();
            int task_state_id = iTaskService.Task_State_Id(Task_State);
            EmployeesTasks newEmpTask = new EmployeesTasks();
            newEmpTask = iTaskService.GetEmplTaskById(id);
            newEmpTask.TaskStatusId = task_state_id;
            if (ModelState.IsValid)
            {

                iTaskService.Edit(newEmpTask);
                return RedirectToAction(nameof(Index));
            }
            return View(newEmpTask);
        }
    }
}
