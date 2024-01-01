using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class admin
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "ID is a required Field")]
        public string id { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is a required Field")]
        [Compare("id", ErrorMessage = "Password is wrong")]
        public string password { get; set; }
    }
}