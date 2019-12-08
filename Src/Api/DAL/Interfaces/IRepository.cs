using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> predicate);

        TEntity GetLastRecord();

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);


        void Remove(TEntity entity);

        void Update(TEntity entity);
         
    }
}
