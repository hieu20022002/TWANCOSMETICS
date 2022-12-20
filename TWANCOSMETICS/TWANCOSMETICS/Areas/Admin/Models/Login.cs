﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TWANCOSMETICS.Areas.Admin.Model
{
    public class Login
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Mời nhập user name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string password { get; set; }
    }
}