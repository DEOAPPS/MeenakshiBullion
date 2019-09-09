using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class InsurenceDetailsController : Controller
    {  // GET: Insurence
        string con = "Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
        // GET: insurance
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Create()
        {
            MInsurence ObjInsurence = new MInsurence();
            return View(ObjInsurence);
        }
        [HttpPost]
        public ActionResult Create(MInsurence ins, HttpPostedFileBase file)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                if (ModelState.IsValid == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "PROC_cust_insurance";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@INSURANCE_NAME", ins.INSURANCE_NAME);
                    cmd.Parameters.AddWithValue("@INSURANCE_TYPE", ins.INSURANCE_TYPE);
                    cmd.Parameters.AddWithValue("@INSURANCE_CLAIM_DATE", ins.INSURANCE_CLAIM_DATE);
                    cmd.Parameters.AddWithValue("@INSURANCE_EXPIRE_DATE ", ins.INSURANCE_EXPIRE_DATE);
                    if (ins.INSURANCE_DOCUMENT_URL != null)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _FileName);
                        file.SaveAs(_path);

                    }
                    cmd.Parameters.AddWithValue("@INSURANCE_DOCUMENT_URL", ins.INSURANCE_DOCUMENT_URL);
                    cmd.Parameters.AddWithValue("@QTYPE", 'I');
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ViewBag.message = "Details Added successfully";
                    ModelState.Clear();
                }
                return View();
            }
        }
    }
}