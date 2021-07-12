using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Class1
    {
        [StringLength(50)]
        [MinLength(5)]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }


        [StringLength(50)]
        [NotMapped]
        [MinLength(5)]
        [Required(ErrorMessage = "confirm password is reqired!")]
        [Compare("password")]
        [DisplayName("Confirm  password")]
        public string confpassword { get; set; }

    }
}