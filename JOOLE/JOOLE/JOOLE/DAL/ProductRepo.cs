using JOOLE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JOOLE.Models;
using Joole.DAL;

namespace JOOLE.DAL
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(JooleEntity context) : base(context)
        {
        }
        public JooleEntity context { get; set; }
     

       
    }

}