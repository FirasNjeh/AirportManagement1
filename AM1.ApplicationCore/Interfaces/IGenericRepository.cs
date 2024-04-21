using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //supprime les elements qui verifie la condition where
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(params object[] keyValues);
        //retourne le 1er element qui verifie la condition where
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        //retourne les elements qui verifie la condition where
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
