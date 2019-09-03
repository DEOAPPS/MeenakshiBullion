using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MCustomerDetails
    {
        public int CUSTOMER_ID { get; set; }
        public string NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string FATHERS_NAME { get; set; }
        public string MOTHERS_NAME { get; set; }
        public string PADDR_ADDRESS { get; set; }
        public string PADDR_DISTRICT { get; set; }
        public string PADDR_STATE { get; set; }
        public string PADDR_COUNTRY { get; set; }
        public string PADDR_PIN_CODE { get; set; }
        public string SADDR_ADDRESS { get; set; }
        public string SADDR_DISTRICT { get; set; }
        public string SADDR_STATE { get; set; }
        public string SADDR_COUNTRY { get; set; }
        public string SADDR_PIN_CODE { get; set; }
        public string GST_NO { get; set; }
        public string SALES_TAX_NO { get; set; }
        public string CENTRAL_TAX_NO { get; set; }
        public string MOBILE_NO { get; set; }
        public string ALTERNATE_NO { get; set; }
        public string EMAIL_ID { get; set; }
        public string REMARKS { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string PHOTO { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string Description { get; set; }
        public short IS_INSPECTION { get; set; }
        public string DOCUMENT_TYPE { get; set; }
        public string STATE { get; set; }
        public string DISTRICT { get; set; }
        public Nullable<int> STATE_ID { get; set; }
        public Nullable<int> DISTRICT_ID { get; set; }
        public Nullable<int> InspectionId { get; set; }
        public string CUSTOMER_TYPE { get; set; }


    }
}