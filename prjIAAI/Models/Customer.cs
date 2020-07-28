using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

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

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "姓名")]
        [MaxLength(length: 50)]
        public string Name { set; get; }

        [Display(Name = "性別")]
        public GenderType Gender { set; get; }

        [Display(Name = "生日")]
        [Required(ErrorMessage = "請選擇{0}")]
        public DateTime BirthDate { set; get; }

        [Display(Name = "申請類別")]
        [Required(ErrorMessage = "請選擇{0}")]
        public MemberType Type { set; get; }

        [Display(Name = "連絡電話(公)")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        public string Tel { set; get; }

        [Display(Name = "手機")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(length: 50)]
        public string CellPhone { set; get; }

        [MaxLength(500)]
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "通訊處")]
        public string Address { set; get; }

        [Display(Name = "Email")]
        [MaxLength(length: 200)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress(ErrorMessage = "格式錯誤")]
        public string Email { set; get; }

        [Display(Name = "國際會籍")]
        public string Membership { set; get; }

        [Display(Name = "現職單位")]
        [Required(ErrorMessage = "{0}必填")]
        public string CurrentJob { set; get; }

        [Display(Name = "職稱")]
        [Required(ErrorMessage = "{0}必填")]
        public string CurrentJobTitle { set; get; }

        [Display(Name = "最高學歷")]
        [Required(ErrorMessage = "{0}必填")]
        public string HighestEducation { set; get; }

        //服務經歷
        [Display(Name = "服務單位")]
        [Required(ErrorMessage = "{0}必填")]
        public string  ServiceUnits { set; get; }

        [Display(Name = "職稱")]
        [Required(ErrorMessage = "{0}必填")]
        public string ServiceJobTitle { set; get; }

        [Display(Name = "年")]
        [Required(ErrorMessage = "{0}必填")]
        public string  StartYear{ set; get; }

        [Display(Name = "月")]
        [Required(ErrorMessage = "{0}必填")]
        public string StartMonth { set; get; }

        [Display(Name = "年")]
        [Required(ErrorMessage = "{0}必填")]
        public string EndYear { set; get; }

        [Display(Name = "月")]
        [Required(ErrorMessage = "{0}必填")]
        public string EndMonth { set; get; }

        [Display(Name = "合計年資(年)")]
        [Required(ErrorMessage = "{0}必填")]
        public string SeniorityYear { set; get; }

        [Display(Name = "合計年資(月)")]
        [Required(ErrorMessage = "{0}必填")]
        public string SeniorityMonth { set; get; }

        [Display(Name = "審核")]
        public ChooseType? Verify { set; get; }
        
    }
}