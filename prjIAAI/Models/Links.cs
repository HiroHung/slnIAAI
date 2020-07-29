using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Links:BackendBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "名稱")]
        public string Title { set; get; }

        [Display(Name = "連結網址")]
        public string LinkUrl { set; get; }

        [Display(Name = "圖片")]
        public string Image { set; get; }

        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "是否展出")]
        public ChooseType Display { set; get; }

        [Display(Name = "排序")]
        public int? Sort { set; get; }
    }
}