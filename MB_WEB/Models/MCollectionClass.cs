using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MCollectionClass
    {
        public int USER_ID { get; set; }
        public string USER_PASSWORD { get; set; }
        public string NAME { get; set; }
        public string USER_ADDRESS { get; set; }
        public string USER_MOBILENO { get; set; }
        public string USER_MAIL_ID { get; set; }
        public Nullable<DateTime> CREATED_DATE { get; set; }
        public Nullable<DateTime> UPDATED_DATE { get; set; }
        public Nullable<DateTime> IS_ACTIVE { get; set; }
        public string USER_TYPE { get; set; }


        public int COLLECTION_ID { get; set; }

        public int CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public double AMOUNT { get; set; }

       

    }


    public class MCustomerCollectionListAg
    {

        public List<MDropDown> GetAgentCollections { get; set; }


        public  Nullable< DateTime> FromDate { get; set; }

        public Nullable<DateTime> Todate { get; set; }


        public int  USER_ID { get; set; }

        public List<MCollectionClass> CustomerCollDt { get; set; }

        public MCustomerCollectionListAg()
        {
            GetAgentCollections = new List<MDropDown>();
            CustomerCollDt = new List<MCollectionClass>();
        }
    }



    public class MCustomerAssign
    {

        public List<MDropDown> AgentDetails { get; set; }


        public string CUSTOMER_NAME { get; set; }

        public int CUSTOMER_ID { get; set; }


        public string COMPANY_NAME { get; set; }

        public string MOBILE_NO { get; set; }

       
        public  Nullable< decimal> AMOUNT { get; set; }

        public int USER_ID { get; set; }

        public string DESCRIPTION { get; set; }
       

        public MCustomerAssign()
        {
            AgentDetails = new List<MDropDown>();
            
        }
    }
}