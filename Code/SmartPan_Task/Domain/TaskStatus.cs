using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            EmployeesTasks = new HashSet<EmployeesTasks>();
        }

        public int TaskStatusId { get; set; }
        public string TaskStatus1 { get; set; }

        public virtual ICollection<EmployeesTasks> EmployeesTasks { get; set; }
    }
}
