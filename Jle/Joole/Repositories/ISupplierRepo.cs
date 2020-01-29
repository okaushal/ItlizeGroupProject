using Joole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole.Repositories
{
    public interface ISupplierRepo : IGenericRepo<SUPPLIER>
    {
        SUPPLIER GetSupplierWithProds(int id);
    }
}