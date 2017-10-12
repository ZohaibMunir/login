using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using login.Models;

namespace login.Controllers
{
    public class loginformsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: loginforms
        public ActionResult Index()
        {
            return View(db.loginforms.ToList());
        }

        // GET: loginforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginform loginform = db.loginforms.Find(id);
            if (loginform == null)
            {
                return HttpNotFound();
            }
            return View(loginform);
        }

        // GET: loginforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_name,Last_name,age,Contact_no,email")] loginform loginform)
        {
            if (ModelState.IsValid)
            {
                db.loginforms.Add(loginform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginform);
        }

        // GET: loginforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginform loginform = db.loginforms.Find(id);
            if (loginform == null)
            {
                return HttpNotFound();
            }
            return View(loginform);
        }

        // POST: loginforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_name,Last_name,age,Contact_no,email")] loginform loginform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginform);
        }

        // GET: loginforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginform loginform = db.loginforms.Find(id);
            if (loginform == null)
            {
                return HttpNotFound();
            }
            return View(loginform);
        }

        // POST: loginforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loginform loginform = db.loginforms.Find(id);
            db.loginforms.Remove(loginform);
            db.SaveChanges();
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
