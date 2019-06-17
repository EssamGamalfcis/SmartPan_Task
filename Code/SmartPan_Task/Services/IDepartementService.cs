using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IDepartementService
    {
        List<Departements> GetAll();
        Departements GetById(int id);
        void Update(Departements dep);
        void Delete(Departements dep);
        Departements Search(string search);
        void Insert(Departements dep);
        List<Employees> GetAllEmp(int id);
        Departements FindBy(string search);


    }
}
