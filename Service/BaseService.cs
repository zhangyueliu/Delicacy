using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Service
{
    public  class BaseService<T> where T:class
    {
        protected DbContext context;

        protected BaseService()
        {
            context = EFDataAccess.CreateContext();
        }

        protected void Add(T model)
        {
            context.Set<T>().Add(model);
        }

        protected void Add<T1>(T1 model) where T1 : class
        {
            context.Set<T1>().Add(model);
        }

        protected void Add<T1>(List<T1> list) where T1 : class
        {
            foreach (T1 item in list)
            {
                Add(item);
            }
        }

        protected void Add(List<T> list)
        {
            foreach (T item in list)
            {
                Add(item);
            }
        }

        protected void Update(T model)
        {
            context.Entry<T>(model).State = EntityState.Modified;
        }


        protected void Update<T1>(T1 model) where T1 : class
        {
            context.Entry<T1>(model).State = EntityState.Modified;
        }
        protected void UpdateStatus(T model, EntityState status)
        {
            context.Entry<T>(model).State = status;
        }
        protected void Delete(T model)
        {
            context.Set<T>().Attach(model);
            context.Entry(model).State = EntityState.Deleted;

        }

        protected void Delete(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        protected void Delete(int id)
        {
            context.Set<T>().Remove(context.Set<T>().Find(id));
        }

        protected void Delete(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Delete(ids[i]);
            }

        }

        protected IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().AsNoTracking().Where(where);
        }

        protected IQueryable<T> Select<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, out int rowCount)
        {
            rowCount = context.Set<T>().OfType<T>().Where(where).Count();
            return context.Set<T>().AsNoTracking().Where(where).OrderBy(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        protected IQueryable<T> SelectDesc<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, out int rowCount)
        {
            rowCount = context.Set<T>().Where(where).Count();
            return context.Set<T>().AsNoTracking().Where(where).OrderByDescending(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        protected IQueryable<T> Select<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby)
        {
            return context.Set<T>().AsNoTracking().Where(where).OrderBy(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        protected IQueryable<T> SelectDesc<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby)
        {
            return context.Set<T>().AsNoTracking().Where(where).OrderByDescending(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        protected T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

        protected T Single(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().AsNoTracking().SingleOrDefault(where);
        }

        protected List<Tresult> SqlQuery<Tresult>(string sqlstr, params object[] parameters)
        {
            var obj = context.Database.SqlQuery<Tresult>(sqlstr, parameters).ToList();
            return (List<Tresult>)obj;
        }

        protected Tresult SqlQueryScalar<Tresult>(string sqlstr, params object[] parameters)
        {
            Tresult obj = context.Database.SqlQuery<Tresult>(sqlstr, parameters).FirstOrDefault();
            return obj;
        }

        protected int ExecuteCUD(string sqlstr, params object[] parameters)
        {
            int count = context.Database.ExecuteSqlCommand(sqlstr, parameters);
            return count;
        }

        protected int Save()
        {
            return context.SaveChanges();
        }

    }
}
