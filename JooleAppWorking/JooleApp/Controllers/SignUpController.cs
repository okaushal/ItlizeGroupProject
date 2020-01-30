using JooleApp.Interface;
using JooleApp.Models;
using JooleApp.RepoImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.IO;
using JooleApp.ModelsDTO;

namespace JooleApp.Controllers
{
    public class SignUpController : Controller
    {
        private ICustomerRepo _repository;
        public SignUpController()
        {
            this._repository = new CustomerRepo(new DBJooleEntities());
        }
        public SignUpController(ICustomerRepo repo)
        {
            _repository = repo;
        }
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCust(CustomerDTO cust)
        {
            DBJooleEntities en = new DBJooleEntities();
            
            //Will Save Image to DB and Images Folder
            string fileName = Path.GetFileNameWithoutExtension(cust.ImageFile.FileName);
            string extension = Path.GetExtension(cust.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            cust.PICTURE = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            cust.ImageFile.SaveAs(fileName);

            //Will Map CustomerDTO to Customer
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CustomerDTO, CUSTOMER>(); });

            IMapper iMapper = config.CreateMapper();
            var source = new CustomerDTO();
            var destination = iMapper.Map<CustomerDTO, CUSTOMER>(cust);

            en.CUSTOMERs.Add(destination);
            en.SaveChanges();

            return View();
        }

        public ActionResult Display(int id)
        {
            CUSTOMER c = new CUSTOMER();

            using (DBJooleEntities db = new DBJooleEntities())
            {
                c = db.CUSTOMERs.Where(x => x.CUSTOMERID == id).FirstOrDefault();
            }

            return View(c);
        }
    }
}