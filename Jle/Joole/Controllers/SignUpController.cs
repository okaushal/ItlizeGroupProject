using AutoMapper;
using Joole.Models;
using Joole.ModelsDTO;
using JOOLE.DAL;
using JOOLE.Repository;
using System;
using System.Collections.Generic;
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
    }
}