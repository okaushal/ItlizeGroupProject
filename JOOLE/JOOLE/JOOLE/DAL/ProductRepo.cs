using JOOLE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JOOLE.Models;

namespace JOOLE.DAL
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(ProductEntities context) : base(context)
        {
        }
      
        public string getDifference(Product A, Product B)
        {
            if (A.Equals(B))
            {
                return "No Difference";
            }
            else
            {
                return "Difference";
            }
           
        }

       
    }

}