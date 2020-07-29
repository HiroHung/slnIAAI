using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Article:BackendBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "網頁主題")]
        public string Title { set; get; }

        [Display(Name = "內容")]
        public string ArticleContent { set; get; }
    }
}