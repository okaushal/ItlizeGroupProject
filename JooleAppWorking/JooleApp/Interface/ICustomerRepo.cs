using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleApp.Interface;
using JooleApp.Models;

namespace JooleApp.Interface
{
    public interface ICustomerRepo : IGenericRepo<CUSTOMER>
    {
        bool checkUserExists(string uname, string pword);
    }
}