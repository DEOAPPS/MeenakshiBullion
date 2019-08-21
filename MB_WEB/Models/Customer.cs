using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class Customer
    {
        public int CUSTOMER_ID { get; set; }
        public String NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string PADDR_DISTRICT { get; set; }
        public string PADDR_STATE { get; set; }
        public string CREATED_DATE { get; set; }
        public string MOBILE_NO { get; set; }
        public string UPDATED_DATE { get; set; }
    }


    public class MCustomerListAgent
    {

        public List<MDropDown> GetAgentCollections { get; set; }


        public Nullable<DateTime> FromDate { get; set; }

        public Nullable<DateTime> Todate { get; set; }


        public int USER_ID { get; set; }

        public List<Customer> CustomeDt { get; set; }

        public MCustomerListAgent()
        {
            GetAgentCollections = new List<MDropDown>();
            CustomeDt = new List<Customer>();
        }
    }
}