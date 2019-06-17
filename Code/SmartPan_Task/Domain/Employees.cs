using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeesTasks = new HashSet<EmployeesTasks>();
            InverseManager = new HashSet<Employees>();
            Users = new HashSet<Users>();
        }

        public int EmpId { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public int EmpSalary { get; set; }
        public string EmpImage { get; set; }
        public int? ManagerId { get; set; }
        public int? DeleteFlag { get; set; }
        public int DepId { get; set; }

        public virtual Departements Dep { get; set; }
        public virtual Employees Manager { get; set; }
        public virtual ICollection<EmployeesTasks> EmployeesTasks { get; set; }
        public virtual ICollection<Employees> InverseManager { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
