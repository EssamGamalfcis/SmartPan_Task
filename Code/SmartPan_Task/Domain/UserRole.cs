using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<Users>();
        }

        public int UserRoleId { get; set; }
        public string UserDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
