using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MInspection
    {
        public List<MDropDown1> GetInspectioinCollections { get; set; }

        public int USER_ID { get; set; }
        public string USER_PASSWORD { get; set; }
        public string NAME { get; set; }
        public string USER_MOBILENO { get; set; }
        public string USER_MAIL_ID { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string IS_ACTIVE { get; set; }
        public string USER_TYPE { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public string FATHER_NAME { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string ADDHAR_NO { get; set; }
        public string PAN_NO { get; set; }
        public string USER_GUID { get; set; }
        public string STATE { get; set; }
        public string DISTRICT { get; set; }
        public Nullable<int> STATE_ID { get; set; }
        public Nullable<int> DISTRICT_ID { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public Nullable<int> PINCODE { get; set; }
        public string CITY { get; set; }
        public string STREET { get; set; }
        public string PASSPORT_SIZE_PHOTO { get; set; }

    }


    public class MDropDown1
    {
        public int Value { get; set; }

        public string Text { get; set; }
    }



}
  
