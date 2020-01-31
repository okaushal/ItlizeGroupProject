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
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepo _repository;

        public ProductController()
        {
            this._repository = new ProductRepo(new JOOLEEntity());
        }

        public ProductController(IProductRepo pro)
        {
            this._repository = pro;
        }
        public ActionResult ProductSummary(IEnumerable<Product> products=null, string subName=null, string picture=null)
        {
            dynamic myModel = new ExpandoObject();

            CUSTOMER new_cust = new CUSTOMER();
            new_cust.PICTURE = picture;
            myModel.customer = new_cust;
            if (products != null)
            {
                myModel.Product = products;
                myModel.Subcat = new SubCategoryRepo(new JOOLEEntity()).GetAll().ToList();
                return View(myModel);

            }
            else if (subName != null)
            {
                myModel.Product = _repository.getProductBySubcat(subName);
                myModel.Subcat = new SubCategoryRepo(new JOOLEEntity()).GetAll().ToList();
                return View(myModel);
            }
            else
            {
                myModel.Product = _repository.GetAll();
                myModel.Subcat = new SubCategoryRepo(new JOOLEEntity()).GetAll().ToList();
                return View(myModel);
            }

        }


        public ActionResult SearchedProducts(string subName, int year1=1980, int year2=2020, string price=null)
        {
            if (subName == null)
            {
                return RedirectToAction("ProductSummary");
            }


            return RedirectToAction("ProductSummary",_repository.getProductFromFilter(subName,year1,year2,price));
        }

        

        public ActionResult Details(int productID)
        {

            Product pr = _repository.GetbyID(productID);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = new ProductDTO();
            var destination = iMapper.Map<Product, ProductDTO>(pr);

            if (destination.sub_catID == 2)
            {
                return View("Details", destination);
            }

            else
            {
                return View("Details", destination);
            }
        }

        ////public ActionResult collectID(int id)
        ////{
        ////    List<int> var = new List<int>();
        ////    var.Add(id);
        ////}
        public ActionResult compareProduct(List<int> ids)
        {
            //int[] idArr = ids.Split(',').Select(int.Parse).ToArray();
            List<Product> products = new List<Product>();

            foreach (var id in ids)
            {
                products.Add(_repository.GetbyID(id));
            }

            return View(products);
        }

    }
}