using JOOLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOOLE.Repository
{
    public interface ISubCategoryRepo : IGenericRepo<Subcat>
    {
        IEnumerable<Subcat> GetSubcatsByText(string text);
    }
}