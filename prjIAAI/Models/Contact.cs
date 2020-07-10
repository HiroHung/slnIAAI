using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "姓名")]
        [MaxLength(length: 50)]
        public string Name { set; get; }

        [Display(Name = "性別")]
        [Required(ErrorMessage = "請選擇{0}")]
        public GenderType Gender { set; get; }

        [Display(Name = "聯絡電話")]
        [MaxLength(length: 50)]
        public string Tel { set; get; }

        [Display(Name = "Email")]
        [MaxLength(length: 200)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress(ErrorMessage = "格式錯誤")]
        public string Email { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        [Display(Name = "詢問標題")]
        public string Title { set; get; }

        [Display(Name = "詢問內容")]
        public string ContactContent { set; get; }

        [Display(Name = "發布時間")]
        public DateTime? PostDate { set; get; }
    }
}