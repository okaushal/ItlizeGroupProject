﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace JooleApp.Interface
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        //Get or Select Items
        TEntity GetbyID(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //Add Functionality
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Delete Objects
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}