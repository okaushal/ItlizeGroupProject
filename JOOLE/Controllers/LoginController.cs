using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOOLE.Models;
using JOOLE.DAL;
using JOOLE.Repository;

namespace JOOLE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login


        private ICustomerRepo _repository;

        public LoginController() 
        {
            this._repository = new CustomerRepo(new JooleEntity());
        }
        public LoginController(ICustomerRepo repo)
        {
            _repository = repo;
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LOGIN(CUSTOMER customer)
        {
            if (ModelState.IsValid)
            {
                if (_repository.checkUserExists(customer.USERNAME, customer.PASSWORD))
                {
                    return RedirectToAction("Search", "Search");
                }
                else
                {
                    return RedirectToAction("Welcome");
                }
            }
            
            return View("Login");
        }
    }
}