using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class Expert:BackendBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "姓名")]
        [MaxLength(length: 50)]
        public string Name { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "現職職稱")]
        public string JobTitle { set; get; }

        [Display(Name = "照片")]
        public string Photo { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "學歷")]
        public string Education { set; get; }

        [Display(Name = "基本介紹")]
        public string Introduction { set; get; }

        [Display(Name = "相關介紹")]
        public string About { set; get; }
    }
}