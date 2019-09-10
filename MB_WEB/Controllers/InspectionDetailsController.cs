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
                    cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
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
                            USER_ID = int.Parse(items[0].ToString()),
                            USER_GUID = items[1].ToString(),
                            NAME = items[2].ToString(),
                            USER_MOBILENO = items[3].ToString(),
                            USER_MAIL_ID = items[4].ToString()
                        });

                    }
                }
                return View(ObjAge);


            }
         }



        public ActionResult Inspectorview(int USER_ID)
        {

            List<Inspectorview> objage = new List<Inspectorview>();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PROC_AGENT_VIEW_LIST";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                cmd.Parameters.AddWithValue("@USER_TYPE", 3);
                cmd.Parameters.AddWithValue("@USER_GUID ", DBNull.Value);
                cmd.Parameters.AddWithValue("@QTYPe", 'V');
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                foreach (DataRow items in dt.Rows)
                {
                    objage.Add(new Models.Inspectorview()
                    {
                        USER_GUID = items[9].ToString(),
                        NAME = items[0].ToString(),
                        USER_MOBILENO = items[1].ToString(),
                        USER_MAIL_ID = items[2].ToString(),
                        CREATED_DATE = items[3].ToString(),
                        UPDATED_DATE = items[4].ToString(),
                        FATHER_NAME = items[5].ToString(),
                        DOB = items[6].ToString(),
                        ADDHAR_NO = items[7].ToString(),
                        PAN_NO = items[8].ToString(),
                        STATE = items[10].ToString(),
                        DISTRICT = items[11].ToString(),
                        ADDRESS1 = items[12].ToString(),
                        ADDRESS2 = items[13].ToString(),
                        PINCODE = items[14].ToString(),
                        CITY = items[15].ToString(),
                        STREET = items[16].ToString(),
                        PASSPORT_SIZE_PHOTO = items[17].ToString()
                    });


                }
                return View(objage);
            }

        }

    }
}