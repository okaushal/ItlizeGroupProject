using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using JooleApp.Interface;
using JooleApp.Models;
using System.Data.Entity;

namespace JooleApp.RepoImplementation
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(DBJooleEntities context) : base(context)
        {

        }

        public DBJooleEntities context
        {
            get
            {
                return _context as DBJooleEntities;
            }
            private set
            {
            }
        }

        public IEnumerable<Product> getProductBySubcat(Subcat subcat)
        {
            return context.Products.Where(m => m.sub_catID == subcat.sub_catID);
        }
    }
}