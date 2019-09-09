using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_WEB.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {


         //sri123_mbdbEntities1 db = new sri123_mbdbEntities1();
         // MInspection objInspe = new MInspection();
         // objInspe.GetStateCollections = db.STATE_TBL.Where(s => s.STATE_ID==STATE_TBL).Select(s => new MDropDown1 { Value = s.USER_ID, Text = s.NAME }).ToList();
          return View();




           
        }
    }
}