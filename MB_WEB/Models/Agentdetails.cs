using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class Agentdetails
    {
        public int USER_ID { get; set; }
            public string USER_GUID { get; set; }
            public string NAME { get; set; }
            public string USER_MOBILENO { get; set; }
            public string USER_MAIL_ID { get; set; }
            public string USER_TYPE { get; set; }

        }
    public class Agentview
    {
        public string USER_GUID { get; set; }
        public string NAME { get; set; }
        public string USER_MOBILENO { get; set; }
        public string USER_MAIL_ID { get; set; }
        public string USER_TYPE { get; set; }
        public int USER_ID { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string FATHER_NAME { get; set; }
        public string DOB { get; set; }
        public string ADDHAR_NO { get; set; }
        public string PAN_NO { get; set; }
        public string STATE { get; set; }
        public string DISTRICT { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string PINCODE { get; set; }
        public string CITY { get; set; }
        public string STREET { get; set; }
        public string PASSPORT_SIZE_PHOTO { get; set; }
    }




}