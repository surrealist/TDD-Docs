using Docs.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Services
{
  public class ServiceBase<T> : IService<T> where T : class
  {
    private readonly AppDb db;
    public ServiceBase(AppDb db) => this.db = db;

    public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate) => db.Set<T>().Where(predicate);
    public IQueryable<T> All() => Query(_ => true);
    public virtual T? Find(params object[] keys) => db.Set<T>().Find(keys);

    public virtual T Add(T item) => db.Set<T>().Add(item).Entity;
    public virtual T Update(T item) => db.Set<T>().Update(item).Entity;
    public virtual T Remove(T item) => db.Set<T>().Remove(item).Entity;

    public int SaveChanges()
      => db.SaveChanges();
  }
}
