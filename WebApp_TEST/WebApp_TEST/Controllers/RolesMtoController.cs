using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_TEST.Models;

namespace WebApp_TEST.Controllers
{
    public class RolesMtoController : Controller
    {
        private WebApp_TESTContext db = new WebApp_TESTContext();

        // GET: RolesMto
        public ActionResult Index()
        {
            RoleClient rc = new RoleClient();
            var listRoles = rc.findAll();
            return View(listRoles);
        }

        // GET: RolesMto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: RolesMto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesMto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,RoleCode,RoleDescription")] Role role)
        {
            if (ModelState.IsValid)
            {
                RoleClient rc = new RoleClient();
                rc.Create(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: RolesMto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleClient rc = new RoleClient();
            var role = rc.find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            return View("Edit", role);
        }

        // POST: RolesMto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,RoleCode,RoleDescription")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                RoleClient rc = new RoleClient();
                rc.Edit(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: RolesMto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleClient rc = new RoleClient();
            var role = rc.find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: RolesMto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleClient rc = new RoleClient();
            var role = rc.Delete(id);
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
