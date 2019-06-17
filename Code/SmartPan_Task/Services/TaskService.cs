using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository;

namespace Services
{
    public class TaskService : ITaskService
    {
        IGenericRepository<Tasks> itaskrepository;
        IGenericRepository<EmployeesTasks> iemployeesTasksrepository;
        IGenericRepository<TaskStatus> itaskstatusrepository;

        public TaskService(IGenericRepository<Tasks> _itaskrepository, IGenericRepository<EmployeesTasks> _iemployeesTasksrepository, IGenericRepository<TaskStatus> _itaskstatusrepository)
        {
            this.itaskrepository = _itaskrepository;
            this.iemployeesTasksrepository = _iemployeesTasksrepository;
            this.itaskstatusrepository = _itaskstatusrepository;
        }
        

        public void Edit(EmployeesTasks Task)
        {
            iemployeesTasksrepository.Update(Task);
        }

      
        public List<EmployeesTasks> GetAll(int Id)
        {
            List<int> emptasksid = iemployeesTasksrepository.FindBy(i => i.EmpId == Id).ToList().Select(a=>a.TaskId).ToList();
            List<int> taskstatusid = iemployeesTasksrepository.FindBy(a => a.EmpId == Id).ToList().Select(a => a.TaskStatusId).ToList();
            List<Tasks> ii= itaskrepository.FindBy(a => emptasksid.Contains( a.TaskId));
            List<EmployeesTasks> isi= iemployeesTasksrepository.FindBy(a => a.EmpId == Id);

            return iemployeesTasksrepository.FindBy(a => a.EmpId==Id);


            
        }

        public EmployeesTasks GetEmplTaskById(int id)
        {
            return iemployeesTasksrepository.FindBy(a => a.Id == id).FirstOrDefault();
        }

        public List<Tasks> GetTasks()
        {
            return itaskrepository.GetAll();
        }

        public List<TaskStatus> GetTaskStatus()
        {
            return itaskstatusrepository.GetAll();
        }

        public int Task_State_Id(string status)
        {
           return itaskstatusrepository.FindBy(a=>a.TaskStatus1.Equals(status)).ToList().Select(a => a.TaskStatusId).FirstOrDefault();
        }

        public int Task_Id(string task_name)
        {
            return itaskrepository.FindBy(a => a.TaskName.Equals(task_name)).ToList().Select(a => a.TaskId).FirstOrDefault();
        }

      
    }
}
