using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MB_WEB.Models;
using System.Configuration;

namespace MB_WEB.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        sri123_mbdbEntities sd = new sri123_mbdbEntities();
        string con = "Data Source=198.38.83.33;Initial Catalog=sri123_mbdb;User ID=sri123_mbdb;Password=Mbdb@123";
        public ActionResult Index()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            MCustomerListAgent objAgent = new MCustomerListAgent();

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
            foreach (var Item in AgentDetails)
            {
                objAgent.GetAgentCollections.Add(new MDropDown()

                {
                    Text = Item.NAME,
                    Value = Item.USER_ID

                });
            }
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CUSTOMER_DETAILS_UNDER_AGENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@USER_ID", 0);
                cmd.Parameters.AddWithValue("@start", string.Empty);
                cmd.Parameters.AddWithValue("@end", string.Empty);
                cmd.Parameters.AddWithValue("@QTYPE", "C");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables.Count > 0)
                    foreach (DataRow items in ds.Tables[0].Rows)
                    {
                        objAgent.CustomeDt.Add(new Customer()
                        {
                            CUSTOMER_ID = Convert.ToInt32(items[0].ToString()),
                            NAME = items[1].ToString(),
                            COMPANY_NAME = items[2].ToString(),
                            PADDR_DISTRICT = items[3].ToString(),
                            PADDR_STATE = items[4].ToString(),
                            MOBILE_NO = items[5].ToString(),
                            CREATED_DATE = items[6].ToString(),
                            UPDATED_DATE = items[7].ToString(),
                        });
                    }
            }
            return View(objAgent);
        }


        [HttpPost]
        public ActionResult Index(MCustomerListAgent objAgent)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
            foreach (var Item in AgentDetails)
            {
                objAgent.GetAgentCollections.Add(new MDropDown()

                {
                    Text = Item.NAME,
                    Value = Item.USER_ID

                });
            }
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CUSTOMER_DETAILS_UNDER_AGENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@USER_ID", objAgent.USER_ID);
                cmd.Parameters.AddWithValue("@start", objAgent.FromDate == null ? string.Empty : objAgent.FromDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@end", objAgent.Todate == null ? string.Empty : objAgent.Todate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@QTYPE", "C");

                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                foreach (DataRow items in dt.Rows)
                {
                    objAgent.CustomeDt.Add(new Customer()
                    {
                        CUSTOMER_ID = Convert.ToInt32(items[0].ToString()),
                        NAME = items[1].ToString(),
                        COMPANY_NAME = items[2].ToString(),
                        PADDR_DISTRICT = items[3].ToString(),
                        PADDR_STATE = items[4].ToString(),
                        MOBILE_NO = items[5].ToString(),
                        CREATED_DATE = items[6].ToString(),
                        UPDATED_DATE = items[7].ToString(),
                    });
                }
            }
            return View(objAgent);
        }

        public ActionResult ChoosenDropDown()
        {
            sri123_mbdbEntities db = new sri123_mbdbEntities();
            Agent objcustomer = new Agent();
            objcustomer.GetCustomerList = db.user_tbl.Select(s => new Agent { USER_ID = s.USER_ID, NAME = s.NAME }).ToList();
            return View(objcustomer);
        }

        public ActionResult Myprofile()
        {
            customer_tbl ObJuser = new customer_tbl();
            int CustId = Convert.ToInt32( Session["cid"].ToString());
            ObJuser = sd.customer_tbl.Where(s => s.CUSTOMER_ID == CustId).Select(s => s).FirstOrDefault();
            return View(ObJuser);
        }

        public ActionResult MyCollectionDetails()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<MCustomer> objAgent = new List<MCustomer>();

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();

            // return View(objAgent);
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CUST_COLL_DATE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            sqlcon.Open();

            cmd.Parameters.AddWithValue("@CUST_ID", Convert.ToInt32(Session["cid"].ToString()));

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables.Count > 0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    objAgent.Add(new MCustomer
                    {
                        CUSTOMER_NAME = Convert.ToString(dr["cust_name"]),
                        COMPANY_NAME = Convert.ToString(dr["COMPANY_NAME"]),
                        NAME = Convert.ToString(dr["AGENTNAME"]),
                        AMOUNT = Convert.ToInt32(dr["AMOUNT"]),
                        CREATED_DATE=Convert.ToDateTime(dr["CREATED_DATE"])
                    });
                }
            cmd.ExecuteNonQuery();
            sqlcon.Close();


            return View(objAgent);
        }

    }
}