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


            sri123_mbdbEntities1 db = new sri123_mbdbEntities1();
            MDistrict objInspe = new MDistrict();
            objInspe.GetStateCollections = db.STATE_TBL.Select(s => new MDropDown2 { Value = s.STATE_ID,Text = s.STATE_NAME }).ToList();
            
            return View(objInspe);





        }
    }
}