using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using JOOLE.Models;

namespace JOOLE.Repository
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        TEntity getByID(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity newItem);
        void Delete(TEntity item);



    }
}
