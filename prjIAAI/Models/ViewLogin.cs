﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjIAAI.Models
{
    public class ViewLogin
    {
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "帳號")]
        [MaxLength(50)]
        public string Account { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "密碼")]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}