using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        IGenericRepository<EmployeesTasks> emptask;
        IGenericRepository<TaskStatus> TaskStatus;
        IGenericRepository<Tasks> Tasks;
        IGenericRepository<Employees> emp;

        public EmployeeTaskService(IGenericRepository<EmployeesTasks> _emptask , IGenericRepository<TaskStatus> _TaskStatus ,IGenericRepository<Tasks> _Tasks, IGenericRepository<Employees> _emp)
        {
            emptask = _emptask;
            TaskStatus = _TaskStatus;
            Tasks = _Tasks;
            emp = _emp;
        }

        public List<EmployeesTasks> GetById(int id)
        {
           return emptask.Include(e => e.Emp).Include(e => e.Task).Include(e => e.TaskStatus).Where(a=>a.Emp.ManagerId==id).OrderBy(a=>a.Emp.EmpFname).ToList();
        }

        public void Add(EmployeesTasks newemptask)
        {
            emptask.Add(newemptask);
        }

        public List<TaskStatus> GetAllTaskStatus()
        {
            return TaskStatus.GetAll();
        }

        public List<Tasks> GetAllTasks()
        {
           return Tasks.GetAll();
        }

        public List<Employees> GetAllEmpByManagerId(int id)
        {
            return emp.FindBy(a => a.ManagerId == id).Where(a=>a.DeleteFlag!=1).ToList();
        }
    }
}
