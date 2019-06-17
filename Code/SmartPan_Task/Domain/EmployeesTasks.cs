using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class EmployeesTasks
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int TaskId { get; set; }
        public int TaskStatusId { get; set; }

        public virtual Employees Emp { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
    }
}
