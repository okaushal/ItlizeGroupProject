using AutoMapper;
using Joole.Models;
using Joole.ModelsDTO;
using JOOLE.DAL;
using JOOLE.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joole.Controllers
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
            DBJooleEntities en = new DBJooleEntities();

            string fileName = Path.GetFileNameWithoutExtension(cust.ImageFile.FileName);
            string extension = Path.GetExtension(cust.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            cust.PICTURE = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            cust.ImageFile.SaveAs(fileName);

            //CUSTOMER c = en.CUSTOMERs.Add(cust);
            //CUSTOMER c = en.CUSTOMERs.ToList().FirstOrDefault();
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