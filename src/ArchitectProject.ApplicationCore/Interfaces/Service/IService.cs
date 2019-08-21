using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.ApplicationCore.Interfaces.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity customer);
        void Update(TEntity customer);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity customer);
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
