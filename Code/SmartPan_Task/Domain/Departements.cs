using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Departements
    {
        public Departements()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public int? DeleteFlag { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
