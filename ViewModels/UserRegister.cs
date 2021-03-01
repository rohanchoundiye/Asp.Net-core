using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class UserRegister
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
