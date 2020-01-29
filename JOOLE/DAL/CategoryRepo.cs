using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Joole.DAL;
using JOOLE.Models;
using JOOLE.Repository;

namespace JOOLE.DAL
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(JooleEntity context) : base(context)
        {
        }
        public JooleEntity context { get; set; }
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
    }
}