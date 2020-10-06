using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using prjIAAI.Filters;
using prjIAAI.Models;

namespace prjIAAI.Areas.Admin.Controllers
{
    [Authorize]
    [PermissionFilters]
    public class MembersController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Admin/Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Admin/Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Members/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Account,Password,PasswordSalt,Email,Gender,Tel,Photo,JobTitle")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Admin/Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            Session["Password"] = member.Password;
            Session["PasswordSalt"] = member.PasswordSalt;
            Session["Photo"] = member.Photo;
            return View(member);
        }

        // POST: Admin/Members/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Account,Password,PasswordSalt,Email,Gender,Tel,Photo,JobTitle")]
            Member member, HttpPostedFileBase Photo)
        {
            //移除驗證
            ModelState.Remove("Account");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                //密碼更改處理
                //檢查是否輸入新密碼
                if (member.Password != null)
                {
                    member.PasswordSalt = Session["PasswordSalt"].ToString();
                    member.Password = Utility.GenerateHashWithSalt(member.Password, member.PasswordSalt);
                }
                else
                {
                    member.Password = Session["Password"].ToString();
                    member.PasswordSalt = Session["PasswordSalt"].ToString();
                }

                //圖片上傳處理
                //判斷資料夾是否存在，若無則建立資料夾
                if (!Directory.Exists("~/FileUploads/"))
                {
                    Directory.CreateDirectory(Server.MapPath("~/FileUploads"));
                }
                //判斷檔案否存在
                if (Photo != null)
                {
                    //判斷是否為圖片類型檔案
                    if (Photo.ContentType.IndexOf("image", System.StringComparison.Ordinal) == -1)
                    {
                        TempData["message"] = "請選擇圖片類型檔案";
                        return View(member);
                    }
                    else
                    {
                        member.Photo = Utility.SaveUpImage(Photo);
                        Utility.GenerateThumbnailImage(Utility.SaveUpImage(Photo), Photo.InputStream,
                            Server.MapPath("~/FileUploads"), "mini", 188);
                    }
                }
                else
                {
                    member.Photo = Session["Photo"].ToString();
                }
                //db.Entry(member).State = EntityState.Modified;
                //db.SaveChanges();
                member.Update();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //// GET: Admin/Members/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        // POST: Admin/Members/Delete/5
        public ActionResult DeleteOK(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
