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
       
      [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "enter 10digits only")]
        public string ADMIN_MOBILENO { get; set; }


        [Required]
        
        public string ADMIN_PASSWORD { get; set; }

    }
}