using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using prjIAAI.Filters;
using prjIAAI.Models;

namespace prjIAAI.Areas.Admin.Controllers
{
    [Authorize]
    [PermissionFilters]
    public class HomeController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Home
        public ActionResult Index()
        {
            //ViewBag.pp = User.Identity.IsAuthenticated;
            return View();
        }

        //登入
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //登入驗證
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Account,Password")] ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                Member member = ValidateUser(viewLogin.Account, viewLogin.Password);
                if (member != null)
                {
                    string userData = JsonConvert.SerializeObject(member);
                    Utility.SetAuthenTicket(userData, viewLogin.Account);
                    return RedirectToAction("Index", "Home");
                }
                TempData["message"] = "登入失敗!";
                return View();
            }
            TempData["message"] = "登入失敗!";

            return View(viewLogin);
        }
        private Member ValidateUser(string userName, string password)
        {
            Member administration = db.Members.SingleOrDefault(o => o.Account == userName);
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

        public ActionResult SizeError()
        {
            return View();
        }
    }
}