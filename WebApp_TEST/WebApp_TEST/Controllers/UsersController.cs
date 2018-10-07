using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_TEST.ViewModels;
using WebApp_TEST.Models;
using WebApp_TEST.Security;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel uvm)
        {
            UserModel userModel = new UserModel();

            if (userModel.Login(uvm.User.Username, uvm.User.Password) == null)
            {

                ViewBag.Error = "Nombre de usuario o contraseña incrorrectos";
                return View("Index");

            }

            SessionPersister.Username = uvm.User.Username;

            return View("Ok");

        }


        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }
    }
}