using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IEmployeeService
    {
        List<Employees> GetAll();
        List<Departements> GetAllDepartements();
        List<Users> GetAllUsers();
        Employees GetById(int id);
        void Add(Employees emp);
        void Update(Employees emp);
        void Delete(Employees emp);
        Employees FindBY(string empname);


    }
}
