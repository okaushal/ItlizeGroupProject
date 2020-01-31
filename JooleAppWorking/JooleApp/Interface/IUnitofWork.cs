using System;
using JooleApp.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleApp.Interface
{
    public interface IUnitofWork : IDisposable
    {
        ICustomerRepo Customers { get; }
        IProductRepo Products { get; }
        int Complete();
    }
}