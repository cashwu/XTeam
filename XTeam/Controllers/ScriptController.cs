using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XTeam.Models;

namespace XTeam.Controllers
{
    public class ScriptController : Controller
    {
        private XTeamEntities db = new XTeamEntities();

        // GET: Script
        public ActionResult Index()
        {
            return View(db.Scripts.ToList());
        }

        // GET: Script/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // GET: Script/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Script/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SqlCommand,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Scripts scripts)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(scripts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scripts);
        }

        // GET: Script/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // POST: Script/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SqlCommand,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Scripts scripts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scripts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scripts);
        }

        // GET: Script/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // POST: Script/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scripts scripts = db.Scripts.Find(id);
            db.Scripts.Remove(scripts);
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
