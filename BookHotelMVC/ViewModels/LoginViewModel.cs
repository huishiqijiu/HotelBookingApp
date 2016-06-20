using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHotelMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address cannot be empty.")]
        [Display(Name = "Email")]
        [RegularExpression(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?", ErrorMessage = "Invalid Email.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "At least four charactors.")]
        public string Password { get; set; }
    }
}