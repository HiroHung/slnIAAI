using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using prjIAAI.Models;

namespace prjIAAI.Areas.Admin.Controllers
{
    [Authorize]
    public class AdministrationsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Administrations
        public ActionResult Index()
        {
            return View(db.Administrations.ToList());
        }

        // GET: Admin/Administrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // GET: Admin/Administrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Administrations/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Account,Password,PasswordSalt,Email,Gender,Tel,Permission,Photo,JobTitle")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Administrations.Add(administration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administration);
        }

        // GET: Admin/Administrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Admin/Administrations/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Account,Password,PasswordSalt,Email,Gender,Tel,Permission,Photo,JobTitle")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Admin/Administrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Admin/Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administration administration = db.Administrations.Find(id);
            db.Administrations.Remove(administration);
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

        //登入
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Account,Password")] ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                Administration administration = ValidateUser(viewLogin.Account, viewLogin.Password);
                if (administration != null)
                {
                    string userData = JsonConvert.SerializeObject(administration);
                    Utility.SetAuthenTicket(userData, viewLogin.Account);
                    return RedirectToAction("Index", "Home");
                }
                TempData["message"] = "登入失敗!";
                return View();
            }
            TempData["message"] = "登入失敗!";

            return View(viewLogin);
        }
        private Administration ValidateUser(string userName, string password)
        {
            Administration administration = db.Administrations.SingleOrDefault(o => o.Account == userName);
            if (administration == null)
            {
                return null;
            }
            string saltPassword = Utility.GenerateHashWithSalt(password, administration.PasswordSalt);
            return saltPassword == administration.Password ? administration : null;
        }

        //登出
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}
