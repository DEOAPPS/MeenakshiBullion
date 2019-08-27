using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MB_WEB.Models;

namespace MB_WEB.Controllers
{
    public class LoginController : Controller
    {
        string con = " Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = string.Empty;
            ViewBag.ErrMessage = string.Empty;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login l)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(con))
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "PROC_MANAGE_ADMIN";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@ADMIN_USERNAME", l.ADMIN_MOBILENO);
                        cmd.Parameters.AddWithValue("@ADMIN_PASSWORD", l.ADMIN_PASSWORD);
                        cmd.Parameters.AddWithValue("@QTYPE", 'A');
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        MUser ObjUser = new MUser();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ObjUser.User_Type = Convert.ToInt32(ds.Tables[0].Rows[0][9].ToString());
                            if (ObjUser.User_Type == 1)
                            {
                                ObjUser.CUSTOMER_ID = 0;
                            }
                            else
                            {

                                ObjUser.CUSTOMER_ID = Convert.ToInt32(ds.Tables[0].Rows[0][10].ToString());
                                Session["cid"] = ObjUser.CUSTOMER_ID;
                            }
                            ObjUser.Email = ds.Tables[0].Rows[0][5].ToString();
                            ObjUser.Name = ds.Tables[0].Rows[0][2].ToString();
                            ObjUser.MobileNumber = ds.Tables[0].Rows[0][4].ToString();
                            ObjUser.User_ID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                            Session["UserType"] = ObjUser.User_Type;
                            Session["uid"] = ObjUser.User_ID;

                            return RedirectToAction("Index", "DashBoard");

                        }
                        else
                        {
                            ViewBag.Message = string.Empty;
                            ViewBag.ErrMessage = "Invalid Credentials.";

                            return View(l);
                        }



                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Empty;
                    ViewBag.ErrMessage = "Internal server Issue.";

                    return View(l);

                }
            }

            return View(l);

        }

        public ActionResult Logout()
        {

            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }


        [HttpGet]
        public ActionResult update()
        {

            return View();
        }
        [HttpPost]
        public ActionResult update(Login l)

        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PROC_MANAGE_ADMIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@ADMIN_USERNAME", l.ADMIN_MOBILENO);
                cmd.Parameters.AddWithValue("@ADMIN_PASSWORD", l.ADMIN_PASSWORD);
                cmd.Parameters.AddWithValue("@QTYPE", 'P');
                cmd.ExecuteNonQuery();
                cn.Close();
                TempData["msg"] = "update password successfully";
                ModelState.Clear();
            }
            return View();
        }

    }
}