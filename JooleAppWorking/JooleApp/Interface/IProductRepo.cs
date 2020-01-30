using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleApp.Interface;
using JooleApp.Models;

namespace JooleApp.Interface
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        IEnumerable<Product> getProductBySubcat(Subcat subcat);
    }
}