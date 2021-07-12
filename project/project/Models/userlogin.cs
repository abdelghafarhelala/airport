using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class userlogin
    {
        [StringLength(50)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "invalid E-mail")]
        public string email { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }

    }
}