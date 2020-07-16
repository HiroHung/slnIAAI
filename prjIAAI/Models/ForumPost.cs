using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class ForumPost
    {
        [Key]
        [Display(Name = "編號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "標題")]
        public string Title { set; get; }

        [Display(Name = "內容")] public string PostContent { set; get; }

        [Display(Name = "發布時間")] public DateTime? PostDate { set; get; }

        [Display(Name = "發布者")] public string Publisher { set; get; }

        [Display(Name = "點閱數")] public int? Clicks { set; get; }

        public virtual ICollection<ForumReply> ForumReplies { set; get; }
    }
}