using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    
        public interface IRepository<T> 
    {
            IEnumerable<T> GetAll();
            T Get(int id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Remove(T entity);
            //T Login_Confirmation(string username , string password);
            void SaveChanges();
            
        }
    
}
