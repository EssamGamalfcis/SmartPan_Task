using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository;

namespace Services
{
    public class DepartementService : IDepartementService
    {
        IGenericRepository<Departements> Departementservice;
        IGenericRepository<Employees> Employeeservice;

        public DepartementService(IGenericRepository<Departements> _Departementservice , IGenericRepository<Employees> _Employeeservice)
        {
            Departementservice = _Departementservice;
            Employeeservice = _Employeeservice;
        }
        public void Delete(Departements dep)
        {
            throw new NotImplementedException();
        }

        public Departements FindBy(string search)
        {
            return Departementservice.Include(a => a.Employees).Where(a => a.DepName.Equals(search) && a.DeleteFlag!=1).FirstOrDefault();
        }

        public List<Departements> GetAll()
        {
          return  Departementservice.GetAll();
        }

        public List<Employees> GetAllEmp(int id)
        {
            return Employeeservice.GetAll().Where(a => a.DepId == id).ToList();
        }

        public Departements GetById(int id)
        {
            return Departementservice.FindBy(a => a.DepId == id).FirstOrDefault();
        }

        public void Insert(Departements dep)
        {
            Departementservice.Add(dep);
        }

        public Departements Search(string search)
        {
            return Departementservice.FindBy(a => a.DepName.Equals(search)).FirstOrDefault();
        }

        public void Update(Departements dep)
        {
            Departementservice.Update(dep);
        }
    }
}
