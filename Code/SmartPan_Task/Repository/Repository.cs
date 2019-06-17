using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class Repository<T> : IRepository<T> where T : class
    {
        private readonly SmartPan_TaskContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(SmartPan_TaskContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }



        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

       

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        
       
        //T IRepository<T>.Login_Confirmation(string username, string password)
        //{
        //   return entities.SingleOrDefault(s => s.name.Equals(username) && s.password.Equals(password));
        //}
    }
}
