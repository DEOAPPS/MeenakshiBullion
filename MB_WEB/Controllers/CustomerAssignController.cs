using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MB_WEB.Controllers
{
    public class CustomerAssignController : Controller
    {
        sri123_mbdbEntities sd = new sri123_mbdbEntities();
        string con = "Data Source=198.38.83.33;Initial Catalog=sri123_mbdb;User ID=sri123_mbdb;Password=Mbdb@123";
        // GET: CustomerAssign
        public ActionResult Index()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<MCustomerAssign> ObjCustomer = new List<MCustomerAssign>();


            var datatable = sd.customer_tbl.Where(s => s.USER_ID == null).Select(s => s).ToList();

            foreach (var Items in datatable)
            {

                ObjCustomer.Add(new MCustomerAssign()
                {
                    COMPANY_NAME = Items.COMPANY_NAME,
                    CUSTOMER_ID = Items.CUSTOMER_ID,
                    MOBILE_NO = Items.MOBILE_NO,
                    CUSTOMER_NAME = Items.NAME

                });
            }
            return View(ObjCustomer);

        }
        [HttpGet]
        public ActionResult AmountAssign(int? CUSTOMER_ID)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.Message = string.Empty;
            ViewBag.ErrMessage = string.Empty;

            if (CUSTOMER_ID != null)
            {
                MCustomerAssign user = new MCustomerAssign();

                var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
                foreach (var Item in AgentDetails)
                {
                    user.AgentDetails.Add(new MDropDown()

                    {
                        Text = Item.NAME,
                        Value = Item.USER_ID

                    });
                }
                
                DataTable agent = new DataTable();
                using (SqlConnection cn = new SqlConnection(con))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "CUSTOMER_ASSIGNEMRNT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USER_ID", string.Empty);
                    cmd.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                    cmd.Parameters.AddWithValue("@NAME", string.Empty);
                    cmd.Parameters.AddWithValue("@MOBILE_NO", string.Empty);
                    cmd.Parameters.AddWithValue("@COMPANY_NAME", string.Empty);
                    cmd.Parameters.AddWithValue("@Qtype", "CA");
                    SqlDataReader dr = cmd.ExecuteReader();
                    agent.Load(dr);
                }
                if (agent.Rows.Count == 1)
                {
                    user.CUSTOMER_NAME = agent.Rows[0][0].ToString();
                    return View(user);
                }
                else

                    return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AmountAssign");
            }


        }
        [HttpPost]
        public ActionResult AmountAssign(MCustomerAssign user)


        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.Message = string.Empty;
            ViewBag.ErrMessage = string.Empty;

          

            var AgentDetails = sd.user_tbl.Where(s => s.USER_TYPE == "2" && s.IS_ACTIVE == "Y").Select(s => s).ToList();
            foreach (var Item in AgentDetails)
            {
                user.AgentDetails.Add(new MDropDown()

                {
                    Text = Item.NAME,
                    Value = Item.USER_ID

                });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(con))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "CUSTOMER_ASSIGN_AGENT";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@USER_ID", user.USER_ID);
                        cmd.Parameters.AddWithValue("@CUSTOMER_ID", user.CUSTOMER_ID);
                        cmd.Parameters.AddWithValue("@AMOUNT", user.AMOUNT);
                        cmd.Parameters.AddWithValue("@Description", user.DESCRIPTION);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        ModelState.Clear();
                        //ViewBag.Message = string.Empty;
                        return RedirectToAction("Index");
                    }
                }
                catch(Exception ex)
                {
                    
                    ViewBag.ErrMessage = "Internal Server Error Please try Again";
                    return View(user);
                }
            }
            else
            {

                return View(user);
            }
        }

    }
}
