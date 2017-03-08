using System;
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
            return View();
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
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Name,SqlCommand")] Scripts script)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Create failed !!"
                });
            }

            script.CreatedBy = UserName;
            script.CreatedOn = DateTime.Now;
            Db.Scripts.Add(script);
            Db.SaveChanges();

            if (script.Id != 0)
            {
               SetBackupScript(script, Remark.Insert);
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
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SqlCommand")] Scripts script)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Edit failed !!"
                });
            }

            var oldScript = Db.Scripts.FirstOrDefault(a => a.Id == script.Id);
            if (oldScript == null)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Edit failed !!"
                });
            }

            oldScript.ModifiedBy = UserName;
            oldScript.ModifiedOn = DateTime.Now;
            oldScript.Name = script.Name;
            oldScript.SqlCommand = script.SqlCommand;

            Db.SaveChanges();

            SetBackupScript(oldScript, Remark.Update);

            return Json(new
            {
                IsSuccess = true,
                Message = "Edit Success !!"
            });
            
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

