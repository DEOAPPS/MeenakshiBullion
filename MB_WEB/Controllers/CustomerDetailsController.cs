using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class CustomerDetailsController : Controller
    {
        // GET: CustomerDetails
        string con = "Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
        public ActionResult Index(MCustomerDetails age)
        {


           
            // GET: Agent

            List<MCustomerDetails> ObjAge = new List<MCustomerDetails>();

            DataTable dt = new DataTable();


            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "USP_CUSTOMER_SEL_INS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", DBNull.Value);
                cmd.Parameters.AddWithValue("QTYPE", 'S');

                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                foreach (DataRow items in dt.Rows)

                {
                    ObjAge.Add(new Models.MCustomerDetails()
                    {
                        CUSTOMER_ID = int.Parse(items[0].ToString()),
                        NAME = items[1].ToString(),
                        CUSTOMER_GUID = items[2].ToString(),
                        MOBILE_NO = items[2].ToString(),
                        AMOUNT = items[4].ToString()

                    });

                }
            }
            return View(ObjAge);

        }
        public ActionResult customerview(int CUSTOMER_ID)
        {

            List<MCusDetails> ObjCus = new List<MCusDetails>();

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "USP_CUSTOMER_SEL_INS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@QTYPE", 'V');
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                foreach (DataRow items in dt.Rows)

                {
                    ObjCus.Add(new Models.MCusDetails()
                    {
                        CUSTOMER_ID = int.Parse(items[0].ToString()),
                        NAME = items[1].ToString(),
                        COMPANY_NAME = items[2].ToString(),
                        FATHERS_NAME = items[3].ToString(),
                        MOTHERS_NAME = items[4].ToString(),
                        PADDR_ADDRESS = items[5].ToString(),
                        PADDR_DISTRICT = items[6].ToString(),
                        PADDR_STATE = items[7].ToString(),
                        PADDR_COUNTRY = items[8].ToString(),
                        PADDR_PIN_CODE = items[9].ToString(),
                        SADDR_ADDRESS = items[10].ToString(),
                        SADDR_DISTRICT = items[11].ToString(),
                        SADDR_STATE = items[12].ToString(),
                        SADDR_COUNTRY = items[13].ToString(),
                        SADDR_PIN_CODE = items[14].ToString(),
                        GST_NO = items[15].ToString(),
                        SALES_TAX_NO = items[16].ToString(),
                        CENTRAL_TAX_NO = items[17].ToString(),
                        MOBILE_NO = items[18].ToString(),
                        ALTERNATE_NO = items[19].ToString(),
                        EMAIL_ID = items[20].ToString(),
                        REMARKS = items[21].ToString(),
                        CREATED_DATE = items[22].ToString(),
                        UPDATED_DATE = items[23].ToString(),
                        PHOTO = items[24].ToString(),
                        AMOUNT = items[25].ToString(),
                        Description = items[26].ToString(),
                        IS_INSPECTION = items[27].ToString(),
                        STATE = items[28].ToString(),
                        DISTRICT = items[29].ToString(),
                        CUSTOMER_TYPE = items[30].ToString(),
                        PADDR_STREET = items[31].ToString(),
                        SADDR_STREET = items[32].ToString(),
                        CUSTOMER_GUID = items[33].ToString()
                    });
                }



                return View(ObjCus);
            }
        }
    }



}











