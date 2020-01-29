using Joole.Models;
using Joole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Joole.DAL.RepoImplementation
{
    public class SupplierRepo : GenericRepo<SUPPLIER>, ISupplierRepo
    {
        public SupplierRepo(DBJooleEntities context) : base(context)
        {
        }

        public SUPPLIER GetSupplierWithProds(int id)
        {
            // Get All the Products supplied by this supplier
            return JooleContext.SUPPLIERs.Include(s => s.Products).SingleOrDefault(s => s.SUPPLIERID == id);
        }
        public DBJooleEntities JooleContext
        {
            get { return _context as DBJooleEntities; }
        }
    }
}