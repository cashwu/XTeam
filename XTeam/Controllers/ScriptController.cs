using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using XTeam.Models;

namespace XTeam.Controllers
{
    public class ScriptController : BaseController
    {
        public ActionResult Index()
        {
            return View(Db.Scripts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = Db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

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
                Db.Scripts.Add(scripts);
                Db.SaveChanges();
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
            Scripts scripts = Db.Scripts.Find(id);
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
                Db.Entry(scripts).State = EntityState.Modified;
                Db.SaveChanges();
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
            Scripts scripts = Db.Scripts.Find(id);
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
            Scripts scripts = Db.Scripts.Find(id);
            Db.Scripts.Remove(scripts);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
