using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Users
    {
        public int UserId { get; set; }
        public int EmpId { get; set; }
        public string UserLoginName { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }

        public virtual Employees Emp { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
