using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JOOLE.Models;
using System.Linq.Expressions;
using JOOLE.Repository;

namespace JOOLE.DAL
{
    public class GenericRepo<TEntity>:IGenericRepo<TEntity> where TEntity:class
    {
        protected readonly DbContext _context;

        public TEntity getByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public GenericRepo(DbContext ctext)
        {
            _context = ctext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        
        }

        public void Create(TEntity newItem)
        {
            _context.Set<TEntity>().Add(newItem);
        }

        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }
    }
}