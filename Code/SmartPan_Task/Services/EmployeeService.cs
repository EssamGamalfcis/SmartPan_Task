using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        IGenericRepository<Employees> emplservice;
        IGenericRepository<Departements> departementservice;
        IGenericRepository<Users> userservice;


        public EmployeeService(IGenericRepository<Employees> _emplservice , IGenericRepository<Departements> _departementservice , IGenericRepository<Users> _userservice)
        {
            emplservice = _emplservice;
            departementservice = _departementservice;
            userservice = _userservice;
        }

        public void Add(Employees emp)
        {
            emplservice.Add(emp);
            
        }

        public void Delete(Employees emp)
        {
            emplservice.Delete(emp);
        }

        public Employees FindBY(string empname)
        {
            return emplservice.Include(a => a.Dep).Where(a => a.EmpFname.Equals(empname) && a.DeleteFlag != 1).FirstOrDefault();
        }

        public List<Employees> GetAll()
        {
           
           return emplservice.Include(a=>a.Dep).ToList();
        }

        public List<Departements> GetAllDepartements()
        {
           return departementservice.GetAll().ToList();
        }

        public List<Users> GetAllUsers()
        {
            return userservice.GetAll().ToList();
        }

        public Employees GetById(int id)
        {
            return emplservice.FindBy(a => a.EmpId == id).FirstOrDefault();
        }

        public void Update(Employees emp)
        {
            emplservice.Update(emp);
        }
    }
}
