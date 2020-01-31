using JOOLE.Repository;
using JOOLE.DAL;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOOLE.Models;
using JOOLE.DAL;
using JOOLE.Repository;
using System.Dynamic;
using AutoMapper;
using JOOLE.ModelsDTO;

namespace JOOLE.Controllers
{
    
    public class SearchController : Controller
    {
        private ISubCategoryRepo _repository;
        public dynamic myModel;


        public SearchController()
        {
            this._repository = new SubCategoryRepo(new JOOLEEntity());
            this.myModel = new ExpandoObject();
        }

        public SearchController(ISubCategoryRepo repo)
        {
            this._repository = repo;
            this.myModel = new ExpandoObject();
        }

        // GET: Search
        public ActionResult Search(CUSTOMER customer=null)
        {
            myModel.cust = customer;
            return View(myModel);
        }

        public JsonResult GetSubcats(string term, string categoryName)
        {
            List<string> subcategories = _repository.GetSubcatsNames(term, categoryName);

            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }
    }
}