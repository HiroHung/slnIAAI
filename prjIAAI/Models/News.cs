using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class News: BackendBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "消息名稱")]
        public string Title { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(60,ErrorMessage = "簡介不可超過 60 字元")]
        [Display(Name = "消息簡述")]
        public string Introduction { set; get; }

        [Display(Name = "內容")]
        public string NewsContent { set; get; }

        [Display(Name = "標題圖片")]
        public string Image { set; get; }

        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "是否置頂")]
        public ChooseType Sticky { set; get; }

        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "是否高光")]
        public ChooseType Highlight { set; get; }

        [Display(Name = "點閱數")]
        public int? Clicks { set; get; }

    }
}