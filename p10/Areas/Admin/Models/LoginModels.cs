using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p10.Areas.Admin.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage ="Mời nhập UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mời nhập PassWord")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}