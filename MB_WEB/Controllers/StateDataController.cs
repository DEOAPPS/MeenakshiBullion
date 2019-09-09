using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class StateDataController : Controller
    {

        string con = "Data Source=198.38.83.33;Initial Catalog=sri123_mbdb;User ID=sri123_mbdb;Password=Mbdb@123";
        // GET: StateData
        [HttpPost]
        public ActionResult Index(MStateData reg)
        {
            using (SqlConnection cn = new SqlConnection(con))

            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into  STATE_TBL values(@STATE_NAME)";
                cmd.Connection = cn;
                cn.Open();
                cmd.Parameters.AddWithValue("STATE_NAME", reg.STATE_NAME);
                cmd.ExecuteNonQuery();
                cn.Close();
             
                return View();
            }
        }

    }
}

 
