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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer user)
        {
            if (ModelState.IsValid)
            {
                using (customerEntities customer=new customerEntities())
                {
                    var obj = customer.getLoginInfo(user.username, user.password).FirstOrDefault();
                    if (obj == "success")
                    {
                        return View("Searching");
                    }else if(obj=="User Does Not Exists"){
                        ViewBag.NotValidUser = obj;

                    }
                    else
                    {
                        ViewBag.FailedCount = obj;
                    }

                }
            }
            return HttpNotFound();


        }
    }
}