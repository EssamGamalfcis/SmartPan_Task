using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public interface IEmployeeTaskService
    {
        void Add(EmployeesTasks emptask);
        List<EmployeesTasks> GetById(int id);
        List<TaskStatus> GetAllTaskStatus();
        List<Tasks> GetAllTasks();
        List<Employees> GetAllEmpByManagerId(int id);

    }
}
