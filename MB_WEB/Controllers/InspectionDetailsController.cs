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
    public class InspectionDetailsController : Controller
    {
        string con = "Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
        // GET: Agent
        public ActionResult Index(MInspectionDetails age)
        {
            {
                if (Session["uid"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                List<MInspectionDetails> ObjAge = new List<MInspectionDetails>();

                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "PROC_AGENT_VIEW_LIST";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USER_TYPE", 3);
                    cmd.Parameters.AddWithValue("@USER_GUID ", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QTYPE", 'S');
                    cmd.Connection = cn;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (DataRow items in dt.Rows)

                    {
                        ObjAge.Add(new Models.MInspectionDetails()
                        {
                            USER_GUID = items[0].ToString(),
                            NAME = items[1].ToString(),
                            USER_MOBILENO = items[2].ToString(),
                            USER_MAIL_ID = items[3].ToString()
                        });

                    }
                }
                return View(ObjAge);


            }
        }
    }
}