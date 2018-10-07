using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_TEST.Models;
using WebApp_TEST.Security;

namespace WebApp_TEST.Controllers
{
    public class UsersMtoController : Controller
    {
        private WebApp_TESTContext db = new WebApp_TESTContext();

        // GET: UsersMto
        [_Authorize(Roles = "ADMIN")]
        public ActionResult Index()
        {
            UserClient uc = new UserClient();
            var listUsers = uc.findAll();

            return View(listUsers);
            
        }

        // GET: UsersMto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersMto/Create
        [_Authorize(Roles = "ADMIN")]
        public ActionResult Create()
        {
            RoleClient rc = new RoleClient();
            var listRoles = rc.findAll();
            ViewBag.RoleCode = new SelectList(listRoles, "RoleCode", "RoleDescription");
            return View();
        }

        // POST: UsersMto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Username,Password,RoleCode")] User user)
        {
            if (ModelState.IsValid)
            {
                UserClient uc = new UserClient();
                ViewBag.CustomerCode = new SelectList(db.Roles, "CustomerCode", "Description", user.RoleCode);
                uc.Create(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: UsersMto/Edit/5
        [_Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClient uc = new UserClient();
            var user = uc.find(id);
            RoleClient rc = new RoleClient();
            var listRoles = rc.findAll();
            ViewBag.RoleCode = new SelectList(listRoles, "RoleCode", "RoleDescription", user.RoleCode);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Edit", user);
        }

        // POST: UsersMto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Username,Password,RoleCode")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                UserClient uc = new UserClient();
                uc.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UsersMto/Delete/5
        [_Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClient uc = new UserClient();
            var user = uc.find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersMto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserClient uc = new UserClient();
            var user = uc.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
