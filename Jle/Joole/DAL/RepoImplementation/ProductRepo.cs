using Joole.Models;
using Joole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Joole.DAL.RepoImplementation
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

        public ProductDTO GetManufName()
        {
            return context.Products.Select(p => new { ProductName = p.prodname, ManufacName = p.Manufacturer.manufname});
            //return context.Products.Where(p => p.productID == id).Select(p => (prodName: p.prodname, ManufName: p.Manufacturer.manufID));
        }

    }
}