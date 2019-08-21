using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_WEB.Models
{
    public class MUser
    {
        public int User_ID { get; set; }

        public int CUSTOMER_ID { get; set; }
        public int User_Type { get; set; }

        public string Name { get; set; }
      
        public string Email { get; set; }
        public string MobileNumber { get; set; }
     
     

        public Messages Msg { get; set; }

        public MUser()
        {
            Msg = new Messages();
        }
    }


    public class MUserLoginPara
    {
       
        public string MobileNo { get; set; }
      
        public string Password { get; set; }
     
       
    }

    public class MCustomerView
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string CompanyName { get; set; }

        public string MobileNumber { get; set; }


    }

    public class MCustomerCollectins
    {
        public int CustomerID { get; set; }
       
         public  double Amount { get; set; }

        public string  CollectionDate { get; set; }

        public string CustomerName { get; set; }


    }

    public class MCustomerCollectinsList
    {
        public Decimal BalanceAmount { get; set; }
       public List<MCustomerCollectins> CollectionDetails { get; set; }

        public Messages Msg { get; set; }

        public  MCustomerCollectinsList()
        {

            CollectionDetails = new List<MCustomerCollectins>();
            Msg = new Messages();
        }

    }

    public class MCustomerDetail
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
        public string SENDER_ID_NO { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string PHOTO { get; set; }

        public Messages Msg { get; set; }

        public  MCustomerDetail()
        {

            Msg = new Messages();
        }


    }
    public class MCustomerList
    {
        public List<MCustomerView> CustomerList { get; set; }

        public Messages Msg { get; set; }

        public MCustomerList()
        {
            CustomerList = new List<MCustomerView>();
            Msg = new Messages();

        }

    }


    public class MCollections
    {

        public int COLLECTION_ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public double AMOUNT { get; set; }
        public string CREATED_DATE { get; set; }
        public int USER_ID { get; set; }

        
    }

    public class MCustomeDt
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
        public string SENDER_ID_NO { get; set; }
        public int USER_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public Nullable<DateTime> UPDATED_DATE { get; set; }
        public string PHOTO { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
    }
}