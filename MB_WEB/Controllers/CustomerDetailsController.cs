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
        public ActionResult Index(MCustomerDetails age)
        {


            string con = "Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
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
    }
}






