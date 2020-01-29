using JOOLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOOLE.Repository
{
    interface ICategoryRepo: IGenericRepo<Category>
    {
        IEnumerable<Category> GetCategories();
    }
}
