using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjIAAI.Filters;
using prjIAAI.Models;

namespace prjIAAI.Areas.Admin.Controllers
{
    [Authorize]
    [PermissionFilters]
    public class IndexImagesController : Controller
    {
        private Model db = new Model();

        // GET: Admin/IndexImages
        public ActionResult Index()
        {
            return View(db.IndexImages.ToList());
        }

        // GET: Admin/IndexImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexImage indexImage = db.IndexImages.Find(id);
            if (indexImage == null)
            {
                return HttpNotFound();
            }
            return View(indexImage);
        }

        // GET: Admin/IndexImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/IndexImages/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Image,LinkUrl,Display,Sort")] IndexImage indexImage)
        {
            if (ModelState.IsValid)
            {
                db.IndexImages.Add(indexImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indexImage);
        }

        // GET: Admin/IndexImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexImage indexImage = db.IndexImages.Find(id);
            if (indexImage == null)
            {
                return HttpNotFound();
            }
            return View(indexImage);
        }

        // POST: Admin/IndexImages/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Image,LinkUrl,Display,Sort")] IndexImage indexImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexImage);
        }

        // GET: Admin/IndexImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexImage indexImage = db.IndexImages.Find(id);
            if (indexImage == null)
            {
                return HttpNotFound();
            }
            return View(indexImage);
        }

        // POST: Admin/IndexImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndexImage indexImage = db.IndexImages.Find(id);
            db.IndexImages.Remove(indexImage);
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
