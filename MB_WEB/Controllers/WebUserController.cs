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
    public class WebUserController : Controller
    {
        string con = "Data Source=198.38.83.33;Initial Catalog=sri123_mbdb;User ID=sri123_mbdb;Password=Mbdb@123";
        // GET: WebUser
        public ActionResult Index(User user)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<User> ObjUser = new List<User>();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PROC_USER_VIEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                foreach (DataRow items in dt.Rows)
                {
                    ObjUser.Add(new Models.User()
                    {
                        NAME = items[1].ToString(),
                        UserID = Convert.ToInt32(items[0].ToString()),
                        USER_TYPE = items[3].ToString(),
                        USER_ADDRESS = items[4].ToString(),
                        USER_MOBILENO = items[5].ToString(),
                        USER_MAIL_ID = items[6].ToString(),
                        CREATED_DATE = items[7].ToString(),
                        UPDATED_DATE = items[8].ToString(),
                        IS_ACTIVE= items[9].ToString(),
                        USER_TYPE_NAME=GetUserTypeName(items[3].ToString())
                    });
                }
            }
            return View(ObjUser);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            User ObjUser = new User();
            ObjUser.UserTypeList.Add(new MDropDown()
            {
                Text = "--SelectUserType--",
                Value = 0

            });
            ObjUser.UserTypeList.Add(new MDropDown()
            {
                Text = "Admin",
                Value = 1
            });

            ObjUser.UserTypeList.Add(new MDropDown()
            {
                Text = "Agent",
                Value = 2

            });
            ObjUser.UserTypeList.Add(new MDropDown()
            {
                Text = "Customer",
                Value = 3

            });

            ViewBag.Message = string.Empty;
            ViewBag.ErrMessage = string.Empty;
            return View(ObjUser);
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.Message = string.Empty;
            ViewBag.ErrMessage = string.Empty;
            user.UserTypeList.Add(new MDropDown()
            {
                Text = "--SelectUserType--",
                Value = 0

            });
            user.UserTypeList.Add(new MDropDown()
            {
                Text = "Admin",
                Value = 1

            });

            user.UserTypeList.Add(new MDropDown()
            {
                Text = "Agent",
                Value = 2

            });
            user.UserTypeList.Add(new MDropDown()
            {
                Text = "Customer",
                Value = 3

            });
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    if (ModelState.IsValid == true)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "PROC_MANAGE_USER";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                        cmd.Parameters.AddWithValue("@NAME", user.NAME);
                        cmd.Parameters.AddWithValue("@USER_PASSWORD", user.USER_PASSWORD);
                        cmd.Parameters.AddWithValue("@USER_TYPE", user.USER_TYPE);
                        cmd.Parameters.AddWithValue("@USER_ADDRESS", user.USER_ADDRESS);
                        cmd.Parameters.AddWithValue("@USER_MOBILENO", user.USER_MOBILENO);
                        cmd.Parameters.AddWithValue("@USER_MAIL_ID", user.USER_MAIL_ID);
                        cmd.Parameters.AddWithValue("@IS_ACTIVE", 'Y');
                        cmd.Parameters.AddWithValue("@QTYPE", 'I');
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        ViewBag.Message = "USER REGISTATION SUCCESSFULLY";
                        ModelState.Clear();    
                    }               
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrMessage = "Internal Server issue registration unsuccessfully";
            }
            return View(user);
        }
        // GET: Default/Edit/5
        [HttpGet]
        public ActionResult Edit(int? USER_ID)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (USER_ID != null)
            {
                User user = new User();
                DataTable student = new DataTable();
                using (SqlConnection cn = new SqlConnection(con))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "PROC_MANAGE_GET";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    student.Load(dr);
                }
                if (student.Rows.Count == 1)
                {
                    user.NAME = student.Rows[0][1].ToString();
                    user.USER_PASSWORD = student.Rows[0][0].ToString();
                    user.USER_TYPE = student.Rows[0][6].ToString();
                    user.USER_ADDRESS = student.Rows[0][2].ToString();
                    user.USER_MOBILENO = student.Rows[0][3].ToString();
                    user.USER_MAIL_ID = student.Rows[0][4].ToString();
                    user.IS_ACTIVE = student.Rows[0][5].ToString();
                    return View(user);
                }
                else
                    return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(User user, int USER_ID)

        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PROC_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                cmd.Parameters.AddWithValue("@NAME", user.NAME);
                cmd.Parameters.AddWithValue("@USER_PASSWORD", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_TYPE", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_ADDRESS", user.USER_ADDRESS);
                cmd.Parameters.AddWithValue("@USER_MOBILENO", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_MAIL_ID", user.USER_MAIL_ID);
                cmd.Parameters.AddWithValue("@IS_ACTIVE", "Y");
                cmd.Parameters.AddWithValue("@QTYPE", 'U');
                cmd.ExecuteNonQuery();
                cn.Close();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
        }
        // GET: Default/Delete/5
        [HttpGet]
        public ActionResult Delete(int USER_ID, string status)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PROC_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                cmd.Parameters.AddWithValue("@NAME", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_ADDRESS", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_PASSWORD", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_MOBILENO", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_MAIL_ID", DBNull.Value);
                cmd.Parameters.AddWithValue("@USER_TYPE", DBNull.Value);
                cmd.Parameters.AddWithValue("@IS_ACTIVE", status);
                cmd.Parameters.AddWithValue("@QTYPE", 'D');
                cmd.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("Index");
            }
        }
        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string GetUserTypeName(string UserType)
        {

            if(UserType=="1")
            {

                return "Admin";
            }
            else if(UserType == "2")
            {

                return "Agent";
            }
            else
            {
                return "Customer";
            }
        }

    }
}