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
    public class LinksController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Links
        public ActionResult Index()
        {
            return View(db.Linkses.ToList());
        }

        // GET: Admin/Links/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Linkses.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // GET: Admin/Links/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Links/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,LinkUrl,Image,Display,Sort")] Links links)
        {
            if (ModelState.IsValid)
            {
                db.Linkses.Add(links);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(links);
        }

        // GET: Admin/Links/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Linkses.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // POST: Admin/Links/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,LinkUrl,Image,Display,Sort")] Links links)
        {
            if (ModelState.IsValid)
            {
                db.Entry(links).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(links);
        }

        // GET: Admin/Links/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Linkses.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // POST: Admin/Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Links links = db.Linkses.Find(id);
            db.Linkses.Remove(links);
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
