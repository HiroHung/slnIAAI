using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class NewsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/News
        public ActionResult Index()
        {
            return View(db.Newses.ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //通過Html標籤驗證
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Introduction,NewsContent,Image,Sticky,Highlight,Clicks,Poster,InitDate,Updater,UpdateDate")] News news, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //圖片上傳處理
                //判斷資料夾是否存在，若無則建立資料夾
                if (!Directory.Exists("~/FileUploads/"))
                {
                    Directory.CreateDirectory(Server.MapPath("~/FileUploads"));
                }
                //判斷檔案否存在
                if (Image != null)
                {
                    //判斷是否為圖片類型檔案
                    if (Image.ContentType.IndexOf("image", System.StringComparison.Ordinal) == -1)
                    {
                        TempData["message"] = "請選擇圖片類型檔案";
                        return View(news);
                    }
                    else
                    {
                        news.Image = Utility.SaveUpImage(Image);
                        Utility.GenerateThumbnailImage(Utility.SaveUpImage(Image), Image.InputStream,
                            Server.MapPath("~/FileUploads"), "mini", 300);
                    }
                }
                //else
                //{
                //    TempData["message"] = "請上傳圖片檔案";
                //    return View(news);
                //}
                //System.Threading.Thread.Sleep(1000);
                db.Newses.Add(news);
                //db.SaveChanges();
                //使用繼承BackendBase中的Function
                news.Create(db,db.Newses);
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Introduction,NewsContent,Image,Sticky,Highlight,Clicks,Poster,InitDate,Updater,UpdateDate")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.Newses.Find(id);
            db.Newses.Remove(news);
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
