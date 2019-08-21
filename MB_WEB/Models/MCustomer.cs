using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MCustomer
    {


        public int USER_ID { get; set; }
        public string NAME { get; set; }
        public int CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public double AMOUNT { get; set; }
        public Nullable<DateTime> CREATED_DATE { get; set; }

    }

}