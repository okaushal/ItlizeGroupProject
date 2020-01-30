using JooleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JooleApp.Interface;
using JooleApp.RepoImplementation;
using System.IO;
using JooleApp.ModelsDTO;


namespace JooleApp.Controllers
{
    public partial class ProductController : Controller
    {
        private IProductRepo _repository;
        public ProductController()
        {
            this._repository = new ProductRepo(new DBJooleEntities());
        }
        public ProductController(IProductRepo repo)
        {
            _repository = repo;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProdDetails(int id)
        {
            DBJooleEntities en = new DBJooleEntities();

            Product pr = _repository.GetbyID(id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDTO>(); });

            IMapper iMapper = config.CreateMapper();
            var source = new ProductDTO();
            var destination = iMapper.Map<Product, ProductDTO>(pr);

            return View(destination);
        }
    }
}