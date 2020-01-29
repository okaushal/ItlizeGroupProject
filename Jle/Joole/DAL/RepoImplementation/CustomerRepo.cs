using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Joole.DAL;
using Joole.DAL.RepoImplementation;
using Joole.Models;
using JOOLE.Repository;

namespace JOOLE.DAL
{
    public class CustomerRepo : GenericRepo<CUSTOMER>, ICustomerRepo
    {
        public CustomerRepo(DBJooleEntities context) : base(context)
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

        public bool checkUserExists(string uname, string pword)
        {
            bool exists = context.CUSTOMERs.Any(m => m.USERNAME == uname && m.PASSWORD == pword);
            if (exists)
            {
                return true;
            }
            return false;
        }
    }

}