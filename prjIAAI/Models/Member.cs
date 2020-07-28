using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace prjIAAI.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "管理者姓名")]
        [MaxLength(length: 50)]
        public string Name { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "帳號")]
        [MaxLength(length: 50)]
        public string Account { set; get; }

        [StringLength(100, ErrorMessage = "{0}長度至少必須為{2}個字", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "密碼")]
        public string Password { set; get; }

        [Display(Name = "密碼鹽")]
        public string PasswordSalt { set; get; }

        [Display(Name = "Email")]
        [MaxLength(length: 200)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress(ErrorMessage = "格式錯誤")]
        public string Email { set; get; }

        [Display(Name = "性別")]
        [Required(ErrorMessage = "請選擇{0}")]
        public GenderType Gender { set; get; }

        [Display(Name = "公司電話")]
        [MaxLength(length: 50)]
        public string Tel { set; get; }

        [Display(Name = "照片")]
        public string Photo { set; get; }

        [Display(Name = "職稱")]
        public string JobTitle { set; get; }

        public virtual ICollection<Role> Roles { set; get; }
    }
}