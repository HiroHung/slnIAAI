using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace prjIAAI.Models
{
    public class Role
    {
        //避免ADD時出錯
        //public Role()
        //{
        //    Administrations=new List<Administration>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { set; get; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "群組名稱")]
        [MaxLength(length: 50)]
        public string GroupName { set; get; }

        [Display(Name = "角色權限")]
        public string Permission { set; get; }

        [JsonIgnore]
        public virtual ICollection<Member> Members { set; get; }
    }
}