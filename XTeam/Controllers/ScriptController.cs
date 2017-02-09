using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using XTeam.Models;
using XTeam.Models.Enum;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,SqlCommand")] Scripts scripts)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Create failed !!"
                });
            }

            scripts.CreatedBy = UserName;
            scripts.CreatedOn = DateTime.Now;
            Db.Scripts.Add(scripts);
            Db.SaveChanges();

            if (scripts.Id != 0)
            {
               SetBackupScript(scripts, Remark.Insert);
            }

            return Json(new
            {
                IsSuccess = true,
                Message = "Create Success !!"
            });
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SqlCommand")] Scripts scripts)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(scripts).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scripts);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scripts scripts = Db.Scripts.Find(id);
            Db.Scripts.Remove(scripts);
            Db.SaveChanges();

            SetBackupScript(scripts, Remark.Delete);

            return RedirectToAction("Index");
        }

        private void SetBackupScript(Scripts scripts, Remark remark)
        {
            var backcupScript = new BackupScripts
            {
                ScriptId = scripts.Id,
                Name = scripts.Name,
                SqlCommand = scripts.SqlCommand,
                CreatedBy = scripts.CreatedBy,
                CreatedOn = scripts.CreatedOn,
                ModifiedBy = scripts.ModifiedBy,
                ModifiedOn = scripts.ModifiedOn,
                Remark = remark.ToString()
            };

            Db.BackupScripts.Add(backcupScript);
            Db.SaveChanges();
        }
    }
}
