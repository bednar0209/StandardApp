using StandardApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using StandardApp.Model;

namespace StandardApp.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : BaseEntity
    {
        [Dependency]
        public AppContext Context { get; set; }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = Context.Set<T>().Where(predicate).AsEnumerable();
            return query;
        }

        public void Delete(int id)
        {
            var query = FindBy(x => x.Id == id).FirstOrDefault();
            if(query != null)
            {
                Delete(query);
            }
            Save();
        }

        private void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Persist(T entity)
        {
            if (entity.Id > 0)
            {
                Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                Context.Set<T>().Add(entity);
            }
            Save();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
