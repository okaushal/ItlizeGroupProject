using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Joole.Models;
using Joole.Repositories;

namespace Joole.Repositories
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        IEnumerable<Product> getProductBySubcat(Subcat subcat);
    }
}