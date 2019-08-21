using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MB_WEB.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER AGENT NAME ")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER PASSWORD")]
        [StringLength(20, ErrorMessage = "PASSWORD MAXIMUM 6 CHARCTERS", MinimumLength = 6)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W])[a-zA-Z0-9\\W]{3,11}")] 
        [DisplayName("PASSWORD")]
        public string USER_PASSWORD { get; set; }

        [Required(ErrorMessage = "PLEASE SELECT USERTYPE")]
        public string USER_TYPE { get; set; }

        public string USER_TYPE_NAME { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER ADDRESS")]
        [StringLength(40, ErrorMessage = "ADDRESS MAXIMUM 3 CHARCTERS", MinimumLength = 3)]
        [DisplayName("ADDRESS")]
        public string USER_ADDRESS { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER MOBILE NUMBER")]
        [DisplayName("MOBILENUMBER")]
        [StringLength(10, ErrorMessage = "MOBILE NUMBER MUST CONTAIN 10 DIGITS", MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string USER_MOBILENO { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER  MAILID")]
        [DisplayName("MAIL_ID")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "MAIL FORMATE IS NOT VALID.")]
        public string USER_MAIL_ID { get; set; }

        public string IS_ACTIVE { get; set; }


        public string CREATED_DATE { get; set; }

        public string UPDATED_DATE { get; set; }

        public List<MDropDown> UserTypeList { get; set; }

        public User()
        {
            UserTypeList = new List<MDropDown>();
        }
    }
    public class MuserList
    {
        public List<MDropDown> UserTypeList { get; set; }

        public List<User> UserList { get; set; }

        public MuserList()
        {
            UserTypeList = new List<MDropDown>();
            UserList = new List<User>();
        }
    }
}