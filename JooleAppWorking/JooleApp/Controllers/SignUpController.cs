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
        public ActionResult Index(CustomerDTO cust)
        {
            using (var unitofwork = new UnitofWork(new DBJooleEntities()))
            {

                //Will Save Image to DB and Images Folder
                string fileName = Path.GetFileNameWithoutExtension(cust.ImageFile.FileName);
                string extension = Path.GetExtension(cust.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cust.PICTURE = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                cust.ImageFile.SaveAs(fileName);

                //Will Map CustomerDTO to Customer
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CustomerDTO, CUSTOMER>(); });

                IMapper iMapper = config.CreateMapper();
                var source = new CustomerDTO();
                var destination = iMapper.Map<CustomerDTO, CUSTOMER>(cust);

                CUSTOMER c = destination;

                unitofwork.Customers.Add(c);
                //en.CUSTOMERs.Add(destination);
                //en.SaveChanges();
                unitofwork.Complete();
            }
            
            return RedirectToAction("Display", new { uname = cust.USERNAME});
        }

        public ActionResult Display(string uname)
        {
            CUSTOMER c = new CUSTOMER();

            using (var unitofwork = new UnitofWork(new DBJooleEntities()))
            {
                c = unitofwork.Customers.Find(x => x.USERNAME == uname).FirstOrDefault();
                //c = db.CUSTOMERs.Where(x => x.USERNAME == uname).FirstOrDefault();
            }

            return View(c);
        }
    }
}