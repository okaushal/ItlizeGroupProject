using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleApp.Interface;
using JooleApp.Models;
using JooleApp.RepoImplementation;

namespace JooleApp.RepoImplementation
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DBJooleEntities _context;

        public UnitofWork(DBJooleEntities context)
        {
            _context = context;
            Customers = new CustomerRepo(_context);
            Products = new ProductRepo(_context);
        }

        public ICustomerRepo Customers { get; private set; }
        public IProductRepo Products { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}