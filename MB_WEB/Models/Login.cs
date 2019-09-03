using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Mobile can't be blank.")]
        [StringLength(10, ErrorMessage = "MOBILE NUMBER MUST CONTAIN 10 DIGITS", MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "MOBILE NUMBER MUST CONTAIN 10 DIGITS")]
        public string ADMIN_MOBILENO { get; set; }

        [Required(ErrorMessage = "Password can't be blank.")]
         public string ADMIN_PASSWORD { get; set; }

    }
}