using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Knowledge:BackendBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "標題")]
        public string Title { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "簡介")]
        public string Introduction { set; get; }

        [Display(Name = "標題圖片")]
        public string Image { set; get; }

        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "是否置頂")]
        public ChooseType Sticky { set; get; }

        [Display(Name = "內容")]
        public string KnowledgeContent { set; get; }
    }
}