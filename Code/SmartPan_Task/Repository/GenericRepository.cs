using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Domain;

using Microsoft.EntityFrameworkCore;


namespace Repository
{
 
    public class GenericRepository<T>: IGenericRepository<T> where T:class
    {

        private readonly SmartPan_TaskContext context;
        private DbSet<T> db;
        public GenericRepository(SmartPan_TaskContext context)
        {
            this.context = context;
            db = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return db .ToList();
        }
        public IQueryable<T> GetAllQ()
        {
            return db ;
        }
        public List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
         
            return  db.Where(predicate).ToList();
        }

        public List<T> FindBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> includes = null)
        {
            return QueryDb(filter, orderBy, includes).ToList();


        }
        public IQueryable<T> FindByQ(Expression<Func<T, bool>> filter=null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> includes = null)
        {
             return   QueryDb(filter, orderBy, includes);

        
        }


        //public List<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        //{


        //}



        public T Add(T entity)
        {
          
            db .Add(entity);
            context.SaveChanges();
            return entity;
        }
        public void Update(T entity)
        {
           // db.Attach(entity);

            db.Update(entity);
            context.SaveChanges();
        }
      
        public void Delete(T entity)
        {
         
            db.Remove(entity);
            context.SaveChanges();
        }
        public IQueryable<T> Include(Expression<Func<T, object>> criteria)
        {
            return db.Include(criteria);
        }


        protected IQueryable<T> QueryDb(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IQueryable<T>> includes)
        {
            IQueryable<T> query = db;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        //public void SQLQuery(string sql, params object[] parameters)
        //{
            
        //     db.Database.ExecuteSqlCommand(sql, parameters);
        //}
  
        //    public ICollection ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        //    {
        //        //if (db.Database.Connection.State == ConnectionState.Closed)
        //        //{
        //        //db.Database.Connection.Open();
        //        //}

        //        var command = db.Database.Connection.CreateCommand();
        //        command.CommandText = commandText;
        //        command.CommandType = commandType;

        //        if (parameters != null)
        //        {
        //            foreach (var parameter in parameters)
        //            {
        //                command.Parameters.Add(parameter);
        //            }
        //        }

        //    DataTable dt = new DataTable();
        //    DbDataAdapter da = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();

        //    da.SelectCommand = command;
        //    da.Fill(dt);
        //            var mapper = new DataReaderMapper<T>();
        //            return mapper.MapToList(dt);
           
        //    }

      
        
    }
}