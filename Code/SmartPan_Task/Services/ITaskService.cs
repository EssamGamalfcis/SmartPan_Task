using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ITaskService
    {
        List<EmployeesTasks> GetAll(int Id);/*return all tasks belong to the empl*/

        void Edit(EmployeesTasks Task);

        EmployeesTasks GetEmplTaskById(int id);
        
        List<TaskStatus> GetTaskStatus();

        List<Tasks> GetTasks();

        int Task_State_Id(string Task_State);

        int Task_Id(string Task_Name);

    }
}
