using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class ForumReply
    {
        [Key]
        [Display(Name = "編號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Display(Name = "回復內容")]
        public string ReplyContent { set; get; }

        [Display(Name = "發布時間")]
        public DateTime? ReplyDate { set; get; }

        [Display(Name = "發布者")]
        public string ReplyPublisher { set; get; }

        public int PostId { set; get; }
        [ForeignKey("PostId")]
        public virtual ForumPost ForumPost { set; get; }
    }
}