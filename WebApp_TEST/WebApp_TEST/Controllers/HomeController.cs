using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_TEST.Models;
using WebApp_TEST.Security;

namespace WebApp_TEST.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [_Authorize(Roles = "ADMIN,PAGE_1")]
        public ActionResult Page1()
        {
            return View("Page_1");
        }


        [_Authorize(Roles = "ADMIN,PAGE_2")]
        public ActionResult Page2()
        {
            return View("Page_2");
        }

        [_Authorize(Roles = "ADMIN,PAGE_3")]
        public ActionResult Page3()
        {
            return View("Page_3");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}