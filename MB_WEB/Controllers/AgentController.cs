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
    public class AgentController : Controller
    {
        string con = "Data Source = 198.38.83.33; Initial Catalog = sri123_mbdb; User ID = sri123_mbdb; Password=Mbdb@123";
        // GET: Agent
        public ActionResult Index(Agentdetails age)
        {
            {
                if (Session["uid"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                List<Agentdetails> ObjAge = new List<Agentdetails>();

                DataTable dt = new DataTable();


                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "PROC_agent_VIEW";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USER_TYPE", 2);
                    cmd.Connection = cn;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (DataRow items in dt.Rows)

                    {
                        ObjAge.Add(new Models.Agentdetails()
                        {
                            USER_ID = Convert.ToInt32(items[0].ToString()),
                            NAME = items[1].ToString(),
                            USER_ADDRESS = items[3].ToString(),
                            USER_MOBILENO = items[4].ToString(),
                            USER_MAIL_ID = items[5].ToString(),
                            USER_TYPE = items[2].ToString(),
                            CREATED_DATE = items[6].ToString(),
                            UPDATED_DATE = items[7].ToString()
                       });

                    }
                }
                return View(ObjAge);
            }
        }
    }
}
    
            


        
    
          
            
                    
            
           

        
           
        
    
