using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public abstract class BackendBase
    {
        [MaxLength(20)]
        [Display(Name = "發布者")]
        public string Poster { get; set; }

        [Display(Name = "發布時間")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        public DateTime? InitDate { get; set; }

        [MaxLength(20)]
        [Display(Name = "更新者")]
        public string Updater { get; set; }

        [Display(Name = "最後更新時間")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 新增
        /// </summary>
        public void Create(Model db, System.Data.Entity.DbSet dbSet)
        {
            if (this.InitDate == null)
            {
                this.InitDate = DateTime.Now;
            }

            this.Poster = System.Web.HttpContext.Current.User.Identity.Name;
            dbSet.Add(this);
            db.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            Model db = new Model();
            this.UpdateDate = DateTime.Now;
            this.Updater = System.Web.HttpContext.Current.User.Identity.Name;
            db.Entry(this).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}