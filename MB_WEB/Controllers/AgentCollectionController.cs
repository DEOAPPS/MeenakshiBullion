using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MB_WEB.Controllers
{
    public class AgentCollectionController : Controller
    {

        sri123_mbdbEntities sd = new sri123_mbdbEntities();
        // GET: AgentCollection

        [HttpGet]
        public ActionResult Index()

        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            MCustomerCollectionListAg objAgent = new MCustomerCollectionListAg();

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
            foreach (var Item in AgentDetails)
            {
                objAgent.GetAgentCollections.Add(new MDropDown()

                {
                    Text = Item.NAME,
                    Value = Item.USER_ID

                });
            }
            // return View(objAgent);
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CollectonDetailsnew";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            sqlcon.Open();


            cmd.Parameters.AddWithValue("@USER_ID", string.Empty);
            cmd.Parameters.AddWithValue("@start", string.Empty);
            cmd.Parameters.AddWithValue("@end", string.Empty);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables.Count > 0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    objAgent.CustomerCollDt.Add(new MCollectionClass
                    {

                        CUSTOMER_NAME = Convert.ToString(dr["cust_name"]),
                        COMPANY_NAME = Convert.ToString(dr["COMPANY_NAME"]),
                        NAME = Convert.ToString(dr["username"]),
                        AMOUNT = Convert.ToInt32(dr["AMOUNT"]),
                    });
                }
            cmd.ExecuteNonQuery();
            sqlcon.Close();


            return View(objAgent);
        }

        [HttpPost]
        public ActionResult Index( MCustomerCollectionListAg cus)

        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CollectonDetailsnew";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            sqlcon.Open();
            MCustomerCollectionListAg lc = new MCustomerCollectionListAg();

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
            foreach (var Item in AgentDetails)
            {
                lc.GetAgentCollections.Add(new MDropDown()

                {
                    Text = Item.NAME,
                    Value = Item.USER_ID

                });
            }

            cmd.Parameters.AddWithValue("@USER_ID", cus.USER_ID);
            cmd.Parameters.AddWithValue("@start", cus.FromDate == null ? string.Empty : cus.FromDate.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", cus.Todate == null ? string.Empty : cus.Todate.Value.ToString("yyyy-MM-dd"));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables.Count > 0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lc.CustomerCollDt.Add(new MCollectionClass
                    {
                        CUSTOMER_NAME = Convert.ToString(dr["cust_name"]),
                        COMPANY_NAME = Convert.ToString(dr["COMPANY_NAME"]),
                        NAME = Convert.ToString(dr["username"]),
                        AMOUNT = Convert.ToInt32(dr["AMOUNT"]),
                        CREATED_DATE= Convert.ToDateTime(dr["CREATED_DATE"]),
                        USER_MOBILENO=Convert.ToString(dr["MOBILE_NO"])
                    });
                }
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            return View(lc);
        }
    }
}