using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Tasks
    {
        public Tasks()
        {
            EmployeesTasks = new HashSet<EmployeesTasks>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public virtual ICollection<EmployeesTasks> EmployeesTasks { get; set; }
    }
}
