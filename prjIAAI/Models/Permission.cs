using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Permission
    {
        [Key]
        [Display(Name = "編號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "側邊欄")]
        [MaxLength(length: 50)]
        public string Subject { set; get; }

        //ForeignKey
        public int? pid { set; get; }

        [Display(Name = "爸爸")]
        [ForeignKey("pid")]
        public virtual Permission permission { set; get; }

        [Display(Name = "孩子")]
        public virtual ICollection<Permission> permissions { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "權限代號")]
        [MaxLength(length: 50)]
        public string pvalue { get; set; }

        [Display(Name = "連結")]
        [MaxLength(length: 200)]
        public string url { get; set; }

        [Display(Name = "圖示")]
        [MaxLength(length: 200)]
        public string icon { get; set; }
    }
}